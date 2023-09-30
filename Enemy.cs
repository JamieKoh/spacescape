using System;
using SplashKitSDK;

namespace CustomProgram{

    /// <summary>
    /// This is the Enemy class
    /// </summary>
    public class Enemy{

        private float X;
        private float Y;
        private Random xnum;
        private Random ynum;
        private Type type;
        int xrand;
        int yrand;
        private Bitmap enemy;

        /// <summary>
        /// This is the class constructor that accepts values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="_enemy"></param>
        /// <param name="_type"></param>
        public Enemy(float x, Bitmap _enemy, Type _type){
            Y = 0;
            X = x;
            xnum = new Random();
            ynum = new Random();
            xrand = xnum.Next(-6, 6);
            yrand = ynum.Next(4, 8);
            enemy = _enemy;
            type = _type;
        }

        /// <summary>
        /// This is the default class constructor
        /// </summary>
        /// <returns></returns>
        public Enemy():this(0, new Bitmap("asteroid", "images/asteroid.png"), Type.asteroid){}

        /// <summary>
        /// This is the property that returns the X attribute
        /// </summary>
        /// <value></value>
        public float x{
            get{return X;}
            set{X = value;}
        }

        /// <summary>
        /// This is the property that returns the Y attribute
        /// </summary>
        /// <value></value>
        public float y{
            get{return Y;}
            set{Y = value;}
        }

        /// <summary>
        /// This is the property that returns the enemy attribute
        /// </summary>
        /// <value></value>
        public Bitmap CurrentEnemy{
            get{return enemy;}
            set{enemy = value;}
        }

        /// <summary>
        /// This is the property that returns the type attribute
        /// </summary>
        /// <value></value>
        public Type Type{
            get{return type;}
            set{type = value;}
        }

        /// <summary>
        /// This is the method that draws the enemy to the game window
        /// </summary>
        /// <param name="window"></param>
        public void Draw(Window window){
            window.DrawBitmap(enemy, X, Y);
        }

        /// <summary>
        /// This is the method that moves the enemy
        /// </summary>
        /// <param name="level"></param>
        public void Move(int level){

            if(level == 1){
                Y = Y + 3;
            }
            else if(level == 2){
                
                if(type == Type.debrisMites){
                    X = X + xrand;
                    Y = Y + yrand;
                }
                else if(type == Type.asteroid){
                    Y = Y + 4;
                }
            }
            else if (level == 3){
                X = X + xrand;
                Y = Y + yrand;
            }
        }
        
    }
}