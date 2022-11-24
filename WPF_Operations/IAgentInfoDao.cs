using System.Collections;

namespace WPF_Operations
{
    public interface IAgentInfoDao
    {
        string AddAgentInfo(AgentInfo agentInfo);
        string UpdateAgentInfo(AgentInfo agentInfo);
        string DeleteAgentInfo(AgentInfo agentInfo);
        IList GetAgentInfo();
    }
}
