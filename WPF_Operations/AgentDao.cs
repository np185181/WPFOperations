using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections;
using System.Linq;

namespace WPF_Operations
{
    public class AgentDao : IAgentInfoDao
    {
        string resultMsg = string.Empty;
        public string AddAgentInfo(AgentInfo agentInfo)
        {
            using (ISession session = SessionFactory.OpenSession)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(agentInfo);
                        transaction.Commit();
                        resultMsg = "New Agent added successfully.";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        resultMsg = ex.Message;
                    }
                }
            }
            return resultMsg;
        }
        public string UpdateAgentInfo(AgentInfo agentInfo)
        {
            using (ISession session = SessionFactory.OpenSession)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(agentInfo);
                        transaction.Commit();
                        resultMsg = "Agent updated successfully.";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        resultMsg = ex.Message;
                    }
                }
            }
            return resultMsg;
        }
        public string DeleteAgentInfo(AgentInfo agentInfo)
        {
            using (ISession session = SessionFactory.OpenSession)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(agentInfo); //delete the record 
                        transaction.Commit(); //commit it 
                        resultMsg = "Agent deleted successfully.";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        resultMsg = ex.Message;
                    }
                }
            }
            return resultMsg;
        }
        public IList GetAgentInfo()
        {
            using (ISession session = SessionFactory.OpenSession)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var contactList = session.Query<AgentInfo>().ToList();
                    return contactList;
                }
            }
        }
    }
}
