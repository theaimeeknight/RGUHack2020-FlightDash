﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDash
{
    /// <summary>
    /// A basic room
    /// </summary>
    public class Room
    {
        /// <summary>
        /// The room name
        /// </summary>
        public string RoomName { get; set; }
        /// <summary>
        /// The room Description
        /// </summary>
        public string RoomDesc { get; set; }
        
        public List<Exit> Exits { get; set; } = new List<Exit>();

    }
}