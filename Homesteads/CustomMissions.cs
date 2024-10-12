using Homesteads.MissionLogics;
using Homesteads.Models;
using SandBox;
using SandBox.Conversation.MissionLogics;
using SandBox.Missions.MissionLogics;
using SandBox.View;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Source.Missions;
using TaleWorlds.MountAndBlade.Source.Missions.Handlers;
using TaleWorlds.MountAndBlade.View;

namespace Homesteads {
    public static class CustomMissions {
        public static Mission StartHomesteadMission(Homestead homestead) {
            string sceneName = homestead.GetHomesteadScene().SceneName;
            return MissionState.OpenNew(sceneName,
                SandBoxMissions.CreateSandBoxMissionInitializerRecord(sceneName, "", false, DecalAtlasGroup.Battle),
                (Mission mission) => new MissionBehavior[] {
                    new MissionOptionsComponent(),
                    new CampaignMissionComponent(),
                    new MissionBasicTeamLogic(),
                    new BasicLeaveMissionLogic(),
                    new MissionAgentLookHandler(),
                    new HeroSkillHandler(),
                    new MissionFacialAnimationHandler(),
                    new BattleAgentLogic(),
                    new MountAgentLogic(),
                    new AgentHumanAILogic(),
                    new MissionHardBorderPlacer(),
                    new MissionBoundaryPlacer(),
                    new MissionBoundaryCrossingHandler(),
                    new EquipmentControllerLeaveLogic(),
                    new MissionConversationLogic(),
                    ViewCreator.CreateMissionLeaveView(),
                    ViewCreator.CreateMissionBoundaryCrossingView(),
                    ViewCreator.CreateMissionAgentStatusUIHandler(mission),
                    ViewCreator.CreateMissionSingleplayerEscapeMenu(false),
                    ViewCreator.CreateOptionsUIHandler(),
                    ViewCreator.CreatePhotoModeView(),
                    SandBoxViewCreator.CreateMissionConversationView(mission),
                    new HomesteadSpawningMissionLogic(homestead),
                    new HomesteadSceneEditingMissionLogic(homestead),
                    new HomesteadConversationMissionLogic(),
                    new HomesteadMissionView(homestead),
                });
        }
    }
}
