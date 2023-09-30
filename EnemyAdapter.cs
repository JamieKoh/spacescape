using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace CustomProgram{

    /// <summary>
    /// This is the EnemyAdapter class that inherits from the abstract PlayerController class. This was implemented as part of my research for the HD task concerning the Adapter design pattern.
    /// </summary>
    public class EnemyAdapter:PlayerController{
        private Enemy currentEnemy;
        private int level;

        /// <summary>
        /// This is the default class constructor
        /// </summary>
        /// <param name="newEnemy"></param>
        /// <param name="_level"></param>
        public EnemyAdapter(Enemy newEnemy, int _level){
            currentEnemy = newEnemy;
            level = _level;
        }

        /// <summary>
        /// This property returns the enemy that the class was initiated with
        /// </summary>
        /// <value></value>
        public Enemy ReturnEnemy{
            get{return currentEnemy;}
            set{currentEnemy = value;}
        }

        /// <summary>
        /// This property draws the enemy to the screen
        /// </summary>
        /// <param name="window"></param>
        public override void Draw(Window window)
        {
            currentEnemy.Draw(window);
        }

        /// <summary>
        /// This property converts the abstract PlayerController class' Move method to work for the Enemy class' Move method
        /// </summary>
        public override void Move()
        {
            currentEnemy.Move(level);
        }
    }
}
