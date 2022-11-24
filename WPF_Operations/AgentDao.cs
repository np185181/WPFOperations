using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections;
using System.Linq;
using NHibernate.Criterion;

namespace WPF_Operations
{
    public class AgentDao : IAgentInfoDao
    {
        private string _resultMsg = string.Empty;

        public string AddOrUpdateAgentInfo(AgentInfo agentInfo)
        {
            using (ISession session = SessionFactory.OpenSession)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        if (GetAgentInfo(agentInfo.AgentId) != null)
                        {
                            session.Update(agentInfo);
                            transaction.Commit();
                            _resultMsg = "Agent updated successfully.";
                        }
                        else
                        {
                            session.Save(agentInfo);
                            transaction.Commit();
                            _resultMsg = "New Agent added successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _resultMsg = ex.Message;
                    }
                }
            }
            return _resultMsg;
        }
        
        public string DeleteAgentInfo(AgentInfo agentInfo)
        {
            using (ISession session = SessionFactory.OpenSession)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        if (GetAgentInfo(agentInfo.AgentId) != null)
                        {
                            session.Delete(agentInfo); //delete the record 
                            transaction.Commit(); //commit it 
                            _resultMsg = "Agent deleted successfully.";
                        }
                        else
                        {
                            _resultMsg = "Agent details not found.";
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _resultMsg = ex.Message;
                    }
                }
            }
            return _resultMsg;
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

        private AgentInfo GetAgentInfo(int agentId)
        {
            if (agentId == 0)
            {
                return null;
            }
            using (ISession session = SessionFactory.OpenSession)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var criteria = session.CreateCriteria<AgentInfo>();
                    criteria.Add(Restrictions.Eq("AgentId", agentId));
                    var agentInfos = criteria.List<AgentInfo>();
                    return agentInfos.FirstOrDefault();
                }
            }
        }
    }
}
