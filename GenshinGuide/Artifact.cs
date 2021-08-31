﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GenshinGuide
{
    public class Artifact
    {
        [JsonProperty] private int gearSlot;
        [JsonProperty] private int rarity;
        [JsonProperty] private int mainStat;
        [JsonProperty] private int level;
        [JsonProperty] private SubStats[] subStats;
        [JsonProperty] private int subStatsCount;
        [JsonProperty] private int setName;
        [JsonProperty] private int equippedCharacter;
        [JsonProperty] private int id;

        public Artifact(int _rarity, int _gearSlot, int _mainStat, int _level, SubStats[] _subStats, int _subStatsCount, int _setName, int _equippedCharacter = 0, int _id = 0)
        {
            gearSlot = _gearSlot;
            rarity = _rarity;
            mainStat = _mainStat;
            level = _level;
            subStats = _subStats;
            subStatsCount = _subStatsCount;
            setName = _setName;
            equippedCharacter = _equippedCharacter;
            id = _id;
        }

        public int GetGearSlot()
        {
            return gearSlot;
        }

        public int GetEquippedCharacter()
        {
            return equippedCharacter;
        }

        public struct SubStats
        {
            public int stat;
            public decimal value;
        }
        
    }

    
}