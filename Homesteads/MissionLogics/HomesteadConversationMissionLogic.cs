using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace Homesteads.MissionLogics {
    public class HomesteadConversationMissionLogic : MissionLogic {
        public override void OnAgentInteraction(Agent userAgent, Agent agent) {
            if (!agent.IsHuman || !userAgent.IsHuman)
                return;
            agent.SetLookAgent(userAgent);
            agent.SetLookToPointOfInterest(userAgent.GetEyeGlobalPosition());
            Campaign.Current.ConversationManager.ConversationEndOneShot += () => {
                agent.SetLookAgent(null);
                agent.SetLookToPointOfInterest(Vec3.Invalid);
            };
        }
    }
}
