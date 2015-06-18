using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace DataValidationApp
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private String server;
        private String port;
        private String database;
        private String uid;
        private String password;
        private String connectionString;


        public Form1()
        {
            InitializeComponent();
            server = "192.168.2.246";
            port = "3306";
            database = "ticketing_spaceneedle_test";
            uid = "dba";
            password = "sql";

            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            if(OpenConnection())
            {
                outputBox.AppendText("Successful Connect" + Environment.NewLine);
            }
            else 
            {
                outputBox.AppendText("Failed Connect" + Environment.NewLine);
            }
           
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }

                MessageBox.Show(ex.Message + ex.StackTrace);                
                return false;
            }
        }

        private void onValidateFunctionalityBtnClick(object sender, EventArgs e)
        {
            String merchantIdToValidate = merchantToCheck.Text;
            //If Print Boca Checked
            if (checkBox1.Checked)
            {
                //Validate App Configs
                //app Id for Passport POS
                String sql = "SELECT a.id, a.description, a.name FROM application a WHERE a.description LIKE '%POS%' OR a.name LIKE '%POS%'";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader results = cmd.ExecuteReader();

                List<String> posApplicationIds = new List<string>();

                while(results.Read())
                {
                    posApplicationIds.Add(results["id"] + "");
                }

                results.Close();

                String sqlToFindAppConfigs = "select ac.name, ac.value from application_config ac join merchant m on ac.merchant_id = m.merchant_id where ac.application_id = @param_val_1 and ac.merchant_id = @param_val_2 and ac.name = 'sendTicketsToBoca' and ac.value = 'true'";
                //String sqlToFindAppConfigs = "select ac.merchant_id, m.display_name, ac.name, ac.value from application_config ac join merchant m on ac.merchant_id = m.merchant_id where ac.application_id = @param_val_1 and ac.name in ('sendTicketsToBoca','groupItemPrinting')";

                bool anyBadResults = false;

                for (int index = 0; index < posApplicationIds.Count; index++)
                {
                    MySqlCommand cmdForAppConfigs = new MySqlCommand(sqlToFindAppConfigs, connection);
                    cmdForAppConfigs.Parameters.AddWithValue("@param_val_1", posApplicationIds[index]);
                    cmdForAppConfigs.Parameters.AddWithValue("@param_val_2", merchantIdToValidate);
                    MySqlDataReader rs = cmdForAppConfigs.ExecuteReader();
                    List<String> merchantIdsWithBocaEnabled = new List<string>();

                    bool hasSendToBocaConfigSetToTrue = false;

                   if(rs.Read())
                   {
                       hasSendToBocaConfigSetToTrue = true;
                   }
                    rs.Close();

                    String sqlForGroupPrintConfig = "select ac.merchant_id, m.display_name, ac.name, ac.value from application_config ac join merchant m on ac.merchant_id = m.merchant_id where ac.application_id = @param_val_1 and ac.name = 'groupItemPrinting' and ac.value = 'true' and ac.merchant_id = @param_val_2";
                    //validate that each one DOESNT have groupItemPrinting set to true
                    MySqlCommand cmdForGroupPrintingConfig = new MySqlCommand(sqlForGroupPrintConfig, connection);
                    cmdForGroupPrintingConfig.Parameters.AddWithValue("@param_val_1", posApplicationIds[index]);
                    cmdForGroupPrintingConfig.Parameters.AddWithValue("@param_val_2", merchantIdToValidate);
                        
                    MySqlDataReader badResults = cmdForGroupPrintingConfig.ExecuteReader();

                    if (badResults.Read() && hasSendToBocaConfigSetToTrue)
                    {
                        outputBox.AppendText("For Merchant ID " + merchantIdToValidate + "change application config values in application_config table for sendTicketsToBoca to true and groupItemPrinting to false!" + Environment.NewLine);
                        anyBadResults = true;
                    }

                    badResults.Close();
                }

                if(!anyBadResults)
                {
                    outputBox.AppendText("All merchants Enabled For Boca Printing!!" + Environment.NewLine);
                }
                
                //Validate Print Formats Exist

                //Make sure all active packages for POS merchants have valid Boca Formats
            }
            

        }

        private void printList(List<String> listToPrint)
        {
            for (int index = 0; index < listToPrint.Count; index++)
            {
                outputBox.AppendText(listToPrint[index]);
            }
        }

    }

}
