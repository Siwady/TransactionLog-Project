using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace TransactionLog
{
    public partial class Form1 : Form
    {


        const int maxBinaryDisplayString = 8000;
        private SqlConnection _con;//=new SqlConnection("Data Source=SIWADY-PC\\SQLSERVER;Integrated Security=SSPI;Initial Catalog=Proyecto");
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
           // Llenar();
        }

        private void Llenar()
        {
            cmd = new SqlCommand
            {
                CommandText =
                    @"SELECT [Transaction ID],[AllocUnitName],[RowLog Contents 0] FROM ::fn_dblog(NULL, NULL)
                               where operation='LOP_DELETE_ROWS'and 
							   [RowLog Contents 0] <> 0x and
							   [AllocUnitName]='dbo." +Table.Text+".PK_"+Table.Text+"'",
                CommandType = CommandType.Text,
                Connection = _con
            };
            _con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd.CommandText, _con);
            adapter.Fill(dt);

            dataGridView1.DataSource = FixBinaryColumnsForDisplay(dt);
            
            cmd.Dispose();
            _con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String rowlogContents0=dataGridView1.CurrentCell.Value.ToString();
            Byte[] bytes=ConvertToBinary(rowlogContents0);
            List<Campos> campos=getCampos();
            //List<CamposNoFijos> camposNofijos = getCamposNofijos(campos);
            List<String> camposVariables = getCamposVarables();
            SetTable(Conversiones.Recorrer(rowlogContents0,campos,camposVariables));
        }

        private List<string> getCamposVarables()
        {
            List<String> camposVariables=new List<string>();
            cmd = new SqlCommand
            {
                CommandText =
                    @"Select column_name as Name,data_type as Tipo from information_schema.columns where TABLE_NAME = '"+Table.Text+"'",
                CommandType = CommandType.Text,
                Connection = _con
            };
            _con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader["Tipo"].ToString().Equals("varchar"))
                {
                    camposVariables.Add(reader["Name"].ToString());
                }
            }
            reader.Close();
            reader.Dispose();
            cmd.Dispose();
            _con.Close();
            return camposVariables;
        }

        private void SetTable(List<Campos> campos)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            for (int i = 0; i < campos.Count; i++)
            {
                dt.Columns.Add(campos.ElementAt(i).Nombre);
            }
            DataRow row = dt.NewRow();

            for (int i = 0; i < campos.Count; i++)
            {
                row[campos.ElementAt(i).Nombre] = campos.ElementAt(i).Valor;
            }
            dt.Rows.Add(row);
            dataGridView1.DataSource = dt;
        }

        private List<Campos> getCampos()
        {
            List<Campos> campos=new List<Campos>();
            cmd = new SqlCommand
            {
                CommandText =
                    @"select colorder, syscolumns.name, systypes.name as NameType ,systypes.length as Size
					from syscolumns
					inner join systypes on syscolumns.xusertype = systypes.xusertype
					where id =object_id('dbo."+this.Table.Text+"') and variable = 0 order by colorder",
                CommandType = CommandType.Text,
                Connection = _con
            };
            _con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                campos.Add(new Campos()
                {
                    Nombre = reader["name"].ToString(),
                    Type = reader["NameType"].ToString(),
                    Tamaño = int.Parse(reader["Size"].ToString())*2
                });
            }
            reader.Close();
            reader.Dispose();
            cmd.Dispose();
            _con.Close();
            return campos;
        }

        public static byte[] ConvertToBinary(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }

        private DataTable FixBinaryColumnsForDisplay(DataTable t)
        {
            List<string> binaryColumnNames = t.Columns.Cast<DataColumn>().Where(col => col.DataType.Equals(typeof(byte[]))).Select(col => col.ColumnName).ToList();
            foreach (string binaryColumnName in binaryColumnNames)
            {
                string tempColumnName = "C" + Guid.NewGuid().ToString();
                t.Columns.Add(new DataColumn(tempColumnName, typeof(string)));
                t.Columns[tempColumnName].SetOrdinal(t.Columns[binaryColumnName].Ordinal);

                StringBuilder hexBuilder = new StringBuilder(maxBinaryDisplayString * 2 + 2);
                foreach (DataRow r in t.Rows)
                {
                    r[tempColumnName] = BinaryDataColumnToString(hexBuilder, r[binaryColumnName]);
                }

                t.Columns.Remove(binaryColumnName);
                t.Columns[tempColumnName].ColumnName = binaryColumnName;
            }
            return t;
        }

        private string BinaryDataColumnToString(StringBuilder hexBuilder, object columnValue)
        {
            const string hexChars = "0123456789ABCDEF";
            if (columnValue == DBNull.Value)
            {
                return "(null)";
            }
            else
            {
                byte[] byteArray = (byte[])columnValue;
                int displayLength = (byteArray.Length > maxBinaryDisplayString) ? maxBinaryDisplayString : byteArray.Length;
                hexBuilder.Length = 0;
                hexBuilder.Append("0x");
                for (int i = 0; i < displayLength; i++)
                {
                    hexBuilder.Append(hexChars[(int)byteArray[i] >> 4]);
                    hexBuilder.Append(hexChars[(int)byteArray[i] % 0x10]);
                }
                return hexBuilder.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            
            connetionString = "Data Source=" + this.DataSource.Text + "\\SQLSERVER;Initial Catalog=" + this.Catalog.Text + ";User ID=" +
                                  this.UserId.Text + ";Password=" + this.Password.Text;
            _con = new SqlConnection(connetionString);
            try
            {
                _con.Open();
                MessageBox.Show("Connected ");
                _con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection fail");
            }
        }

        private void bt_Cargar_Click(object sender, EventArgs e)
        {
            Llenar();
        }

    }

}
