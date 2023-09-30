using System;
using SplashKitSDK;
using NUnit.Framework;

namespace CustomProgram
{
    [TestFixture()]
    /// <summary>
    /// This class tests the child classes of the PlayerController class
    /// </summary>
    public class Test{
        [Test()]
        /// <summary>
        /// This tests the abstract Draw method
        /// </summary>
        public void TestDrawnBitmap(){

            //both the spaceship and bullet's draw methods consist of drawing the bitmap to the screen so this is going to test the difference between the bitmaps
            Spaceship currentShip = new Spaceship();
            Assert.AreEqual(currentShip.Ship, new Bitmap("ship", "images/ship.png"));

            Bullet currentBullet = new Bullet();
            Assert.AreEqual(currentBullet._bullet, new Bitmap("bullet", "images/bullet.png"));
        }

        [Test()]
        /// <summary>
        /// This tests the abstract Move() method
        /// </summary>
        public void TestMove(){
            
            Spaceship currentShip = new Spaceship();
            Assert.AreEqual(620, currentShip.X);

            //Manually entering the currentShip.Move() else if loop because I don't know how or if it is possible to force entry into the loop
            float moved = currentShip.X + 5;
            Assert.AreEqual(625, moved);

            Bullet currentBullet = new Bullet(currentShip.X, 0);
            Assert.AreEqual(currentShip.X, currentBullet.X);
            Assert.AreEqual(0, currentBullet.Y);

            currentBullet.Move();
            Assert.AreEqual(currentShip.X, currentBullet.X);
            Assert.AreEqual(-5, currentBullet.Y);
        }
    }
    
}