﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace Pacman_Atari
{
    class Items
    {
        #region Objetos moveis no cenario
        public static List<Object> objList = new List<Object>();

        public static Pacman pacman;

        public static Ghost ghostGreen;

        public static Ghost ghostLemonade;

        public static Ghost ghostWhiteGreen;

        public static Ghost ghostYellow;
        #endregion

        #region Objetos estaticos no cenario
        public static List<ObjectStatic> objMovList = new List<ObjectStatic>();
        #endregion

        #region Initialize
        public static void Initialize()
        {
            pacman = new Pacman(new Vector2(166, 119), 1, "pacman_animation","debug");
            ghostGreen = new Ghost(new Vector2(270, 450), 1, "ghost_green_animation");
            ghostLemonade = new Ghost(new Vector2(290, 450), 1, "ghost_lemonade_animation");
            ghostWhiteGreen = new Ghost(new Vector2(310, 450), 1, "ghost_white-green_animation");
            ghostYellow = new Ghost(new Vector2(330, 450), 1, "ghost_yellow_animation");
            objList.Add(pacman);
            objList.Add(ghostGreen);
            objList.Add(ghostLemonade);
            objList.Add(ghostWhiteGreen);
            objList.Add(ghostYellow);

            int[,] map = new int[41, 40]
            {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,0,0,1,1,0,0,2,0,0,0,2,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,0,0,1,1,0,0,2,0,0,0,2,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0},
                {1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,0,0,1,1,0,0,2,0,0,0,2,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,1,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0}
                
            };

            int blockSize = 4;
            int mapSize = Game1.screenWidth - 4;
            int dotOffSet = 3;
            int pillOffSet = 2;

            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    switch (map[j, i])
                    {
                        case 1: 
                            objMovList.Add(
                                new Tile(
                                    new Vector2(i * blockSize, j * blockSize), 
                                    new Vector2(blockSize, blockSize), 
                                    "block_tile",
                                    Color.White));
                            objMovList.Add(
                                new Tile(new Vector2((mapSize) - (i * blockSize), j * blockSize), 
                                    new Vector2(blockSize, blockSize), 
                                    "block_tile", 
                                    Color.White));
                            break;
                        case 2:
                            objMovList.Add(
                                new Dot(
                                    new Vector2(i * blockSize, (j * blockSize) + dotOffSet), 
                                    "block_tile", 
                                    Color.White));
                            objMovList.Add(
                                new Dot(
                                    new Vector2((mapSize) - (i * blockSize), (j * blockSize) + dotOffSet), 
                                    "block_tile", 
                                    Color.White));
                            break;

                        case 3:
                            objMovList.Add(
                                new Pill(
                                    new Vector2(i * blockSize, (j * blockSize) + pillOffSet), 
                                    "pill_tile", 
                                    Color.White));
                            objMovList.Add(
                                new Pill(
                                    new Vector2((mapSize) - (i * blockSize) - blockSize, (j * blockSize) + pillOffSet),
                                    "pill_tile",
                                    Color.White));
                            break;

                        default:
                            break;
                    }
                }
            }
        }
        #endregion
    }
}
