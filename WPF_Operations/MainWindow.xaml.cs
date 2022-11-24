using System;
using System.Windows;

namespace WPF_Operations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAgentInfoDao _agentInfoDao;
        private string _response = string.Empty;
        public MainWindow()
        {
            _agentInfoDao = App.container.Resolve<IAgentInfoDao>();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetAllAgents();
        }
        private void GetAllAgents()
        {
            try
            {
               var agentDetails = _agentInfoDao.GetAgentInfo();
               dataGridContact.ItemsSource = agentDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            AgentInfo agentInfo = SetAgentInfo();
            try
            {
                if (btnAdd.Content.ToString() == "Add")
                {
                    _response = _agentInfoDao.AddAgentInfo(agentInfo);
                    MessageBox.Show(_response);
                    GetAllAgents();
                }
                else
                {
                    _response= _agentInfoDao.UpdateAgentInfo(agentInfo); //update the new record 
                    MessageBox.Show(_response);
                    GetAllAgents(); //display the updated record 
                }
                ClearControlsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedAgent = dataGridContact.SelectedItem;
            BindAgentInfo(selectedAgent as AgentInfo);
            btnAdd.Content = "Submit";
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to delete?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
            {
                try
                {
                    var selectedAgent = dataGridContact.SelectedItem as AgentInfo;
                    _response= _agentInfoDao.DeleteAgentInfo(selectedAgent); //delete the record 
                    MessageBox.Show(_response);
                    GetAllAgents(); //display the new collection 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ClearControlsData();
        }
        private AgentInfo SetAgentInfo()
        {
            AgentInfo agentInfo = new AgentInfo();
            agentInfo.FirstName = txtFirstName.Text;
            agentInfo.LastName = txtLastName.Text;
            agentInfo.Mobile = txtMobile.Text;
            agentInfo.Age =Convert.ToInt32(txtAge.Text);
            if (btnAdd.Content.ToString() == "Submit")
            {
                agentInfo.AgentId= Convert.ToInt32(txtContactId.Text);
            }
            return agentInfo;
        }
        private void BindAgentInfo(AgentInfo agentInfo)
        {

            txtFirstName.Text = agentInfo.FirstName;
            txtLastName.Text=agentInfo.LastName;
            txtMobile.Text = agentInfo.Mobile;
            txtAge.Text = Convert.ToString(agentInfo.Age);
            txtContactId.Text = Convert.ToString(agentInfo.AgentId);
        }
        private void ClearControlsData()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtAge.Text = "0";
            txtContactId.Text = string.Empty;
            btnAdd.Content = "Add";
        }
    }
}
