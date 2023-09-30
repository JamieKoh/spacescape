using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace CustomProgram{

    /// <summary>
    /// This is the Spaceship class that inherits from the abstract PlayerController class
    /// </summary>
    public class Spaceship:PlayerController{
        private int _lives;
        private float _y;
        private Bitmap heart;
        private Bitmap ship; 

        /// <summary>
        /// This is the default constructor of the class
        /// </summary>
        public Spaceship(){
            ship = new Bitmap("ship", "images/ship.png");
            heart = new Bitmap("heart", "images/heart.png");
            _y = 750 - ship.Height;
            X = 620;
            _lives = 3;
        }
        
        /// <summary>
        /// This property returns the number of lives of the spaceship
        /// </summary>
        /// <value></value>
        public int Lives{
            get{return _lives;}
            set{_lives = value;}
        }

        /// <summary>
        /// This property returns the ship Bitmap
        /// </summary>
        /// <value></value>
        public Bitmap Ship{
            get{return ship;}
            set{ship = value;}
        }

        /// <summary>
        /// This is the Draw method that the Spaceship class overrides from the PlayerController
        /// </summary>
        /// <param name="window"></param>
        public override void Draw(Window window)
        {
            window.DrawBitmap(ship, X, _y);
        }

        /// <summary>
        /// This method Draws the hearts indicating the number of lives the player has remaining to the game window
        /// </summary>
        /// <param name="window"></param>
        public void DrawLives(Window window){

            if(_lives == 3){
                window.DrawBitmap(heart, 5, 1);
                window.DrawBitmap(heart, 55, 1);
                window.DrawBitmap(heart, 105, 1);
            }
            else if(_lives == 2){
                window.DrawBitmap(heart, 5, 1);
                window.DrawBitmap(heart, 55, 1);
            }
            else if(_lives == 1){
                window.DrawBitmap(heart, 5, 1);
            }
            
        }

        /// <summary>
        /// This is the Move method that the Spaceship class overrides from the abstract PlayerController class
        /// </summary>
        public override void Move(){

            if(SplashKit.KeyDown(KeyCode.LeftKey) && X > 0){
                base.X = X - 5;
            }
            else if(SplashKit.KeyDown(KeyCode.RightKey) && X < (1395 - ship.Width)){
                base.X = X + 5;
            }
        }

        /// <summary>
        /// This method creates a Bullet object at the position of the spaceship so that
        /// </summary>
        /// <param name="bullets"></param>
        public void createBullet(List<Bullet> bullets){
            float bx = X + (ship.Width/2) - 5;
            bullets.Add(new Bullet(bx, _y - 25));
        }

        /// <summary>
        /// This method checks to see if an enemy object's position intersects with the spaceship's position
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public Boolean CheckIfHit(Enemy e){
            Boolean hit;
            hit = SplashKit.BitmapCollision(ship, X, _y, e.CurrentEnemy, e.x, e.y);
            return hit;
        }
    }
}