using System;
using SplashKitSDK;

namespace CustomProgram
{

    /// <summary>
    /// This is the abstract PlayerController class that has 3 children classes: Spaceship, Bullet and Enemy
    /// </summary>
    public abstract class PlayerController
    {
        private float _x;
        private float _y;

        /// <summary>
        /// This is the default class constructor
        /// </summary>
        public PlayerController():this(0){
        }

        /// <summary>
        /// This is the class constructor that accepts values
        /// </summary>
        /// <param name="x"></param>
        public PlayerController(float x){
            _x = x;
            _y = 0;
        }

        /// <summary>
        /// This is the property that returns the X attribute
        /// </summary>
        /// <value></value>
        public float X{
            get{return _x;}
            set{_x = value;}
        }

        /// <summary>
        /// his is the property that returns the Y attribute
        /// </summary>
        /// <value></value>
        public float Y{
            get{return _y;}
            set{_y = value;}
        }

        /// <summary>
        /// This is the abstract Draw method
        /// </summary>
        /// <param name="window"></param>
        public abstract void Draw(Window window);

        /// <summary>
        /// This is the abstract Move method
        /// </summary>
        public abstract void Move();
    }
}