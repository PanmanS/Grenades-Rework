﻿using Microsoft.Xna.Framework;

namespace Barotrauma
{
    class MissionMode : GameMode
    {
        private Mission mission;

        public override Mission Mission
        {
            get
            {
                return mission;
            }
        }

        public MissionMode(GameModePreset preset)
            : base(preset)
        {
            Location[] locations = new Location[2];

            MTRandom rand = new MTRandom(ToolBox.StringToInt(GameMain.NetLobbyScreen.LevelSeed));

            for (int i = 0; i < 2; i++)
            {
                locations[i] = Location.CreateRandom(new Vector2((float)rand.NextDouble() * 10000.0f, (float)rand.NextDouble() * 10000.0f));
            }
            mission = Mission.LoadRandom(locations, rand);
        }

        public override void Start()
        {
            base.Start();

            new GUIMessageBox(mission.Name, mission.Description, 400, 400);

            Networking.GameServer.Log("Mission: " + mission.Name, Color.Cyan);
            Networking.GameServer.Log(mission.Description, Color.Cyan);

        }
    }
}