﻿using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Room_Service
    {
        Room_DAO room_db = new Room_DAO();

        public List<Room> GetRooms()
        {
            try { 
            
                List<Room> studentList = room_db.Db_Get_All_Rooms();
                
                return studentList;
            }
            catch (Exception e)
            {
                Console.Write(e);
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Room> rooms = new List<Room>();
                Room a = new Room();
                a.Capacity = 1;
                a.Number = 474791;
                Room b = new Room();
                b.Capacity = 1;
                b.Number = 474791;
                rooms.Add(a);
                rooms.Add(b);
                return rooms;
                //throw new Exception("Someren couldn't connect to the database");
            }
            
        }
    }
}
