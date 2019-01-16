using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace WpfOracleTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        OracleConnection conn;
        private void DB_Connect(object sender, RoutedEventArgs e)
        {
            try
            {
                string strCon = @"Data Source=(DESCRIPTION =
                         (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.27)(PORT = 1521))
                                    (CONNECT_DATA =
                                      (SERVER = DEDICATED)
                                      (SERVICE_NAME = topcredu)
                                    )
                                  )  ;User Id=scott;Password=tiger";

                conn = new OracleConnection(strCon);
                conn.Open();
                MessageBox.Show("DB Connection OK!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        private void Select_Emp(object sender, RoutedEventArgs e)
        {
            string sql = "select empno, ename, job from emp ";
            OracleCommand comm = new OracleCommand();
            if (conn == null) DB_Connect(this, null);
            comm.Connection = conn;
            comm.CommandText = sql;

            OracleDataReader reader =
           comm.ExecuteReader(CommandBehavior.CloseConnection);
            List<EmpViewModel> emps = new List<EmpViewModel>();
            while (reader.Read())
            {
                emps.Add(new EmpViewModel()
                {
                    Empno =
               reader.GetInt32(reader.GetOrdinal("empno")),
                    Ename =
               reader.GetString(reader.GetOrdinal("ename")),
                    Job =
               reader.GetString(reader.GetOrdinal("job"))
                });
            }
            lstView.ItemsSource = emps;
            reader.Close();
        }

        private void Select_Emp2(object sender, RoutedEventArgs e)
         {

         OracleDataAdapter adapter = new OracleDataAdapter();

                string sql = "select empno, ename, job from emp ";

                OracleCommand comm = new OracleCommand();
         if (conn == null) DB_Connect(this, null);
                comm.Connection = conn;
        comm.CommandText = sql;

         adapter.SelectCommand = comm;

         DataSet ds = new DataSet("emps");
                adapter.Fill(ds, "emp");

         // Clear the ListView control
         lstView.Items.Clear();

         List<EmpViewModel> emps = new List<EmpViewModel>();

         for (int i = 0; i<ds.Tables["emp"].Rows.Count; i++)
         {
         DataRow dr = ds.Tables["emp"].Rows[i];
                emps.Add(new EmpViewModel()
                {
                    Empno = System.Convert.ToInt32(dr["empno"]),
         Ename = dr["ename"].ToString(),
         Job = dr["job"].ToString()
                });
         }

            lstView.ItemsSource = emps;
         conn.Close();
         }

        /* Linq 쿼리식을 통한 EMP 테이터 추출 */
        private void Select_Emp3(object sender, RoutedEventArgs e)
        {
            OracleDataAdapter adapter = new OracleDataAdapter();

            string sql = "select empno, ename, job from emp ";

            OracleCommand comm = new OracleCommand();
            if (conn == null) DB_Connect(this, null);
            comm.Connection = conn;
        adapter.SelectCommand = comm;
            comm.CommandText = sql;
            DataSet ds = new DataSet("emps");
            adapter.Fill(ds, "emp");

            // Clear the ListView control
            lstView.Items.Clear();

            List<EmpViewModel> emps = new List<EmpViewModel>();
            IEnumerable query = from myemp1 in ds.Tables["emp"].AsEnumerable()
                                where myemp1["job"].Equals("CLERK")
                                select myemp1;

            foreach (DataRow dr in query)
            {
                emps.Add(new EmpViewModel()
                {
                    Empno = System.Convert.ToInt32(dr["empno"]),
                    Ename = dr["ename"].ToString(),
                    Job = dr["job"].ToString()
                });
            }

            lstView.ItemsSource = emps;
            conn.Close();
        }
    }
}