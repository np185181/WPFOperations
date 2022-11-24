using System.Collections;

namespace WPF_Operations
{
    /// <summary>
    /// IAgentInfoDao
    /// </summary>
    public interface IAgentInfoDao
    {
        string AddOrUpdateAgentInfo(AgentInfo agentInfo);

        string DeleteAgentInfo(AgentInfo agentInfo);

        IList GetAgentInfo();
    }
}
