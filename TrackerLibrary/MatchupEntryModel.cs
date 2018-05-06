﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// Represents one team in matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// Represents the score of the particular team         
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// Represents the matchup that this team came from as the winner
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialScore">
        /// </param>
        public MatchupEntryModel(double initialScore)
        {
                
        }
    }
}
