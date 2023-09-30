using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace CustomProgram{

    /// <summary>
    /// This is the Drawing class
    /// </summary>
    public class Drawing{
        private readonly List<Bullet> _bullets;
        private List<Star> _stars;
        private List<EnemyAdapter> _enemies;
        private Spaceship _ship;
        private Color _background;
        private Random _random;

        /// <summary>
        /// This is the default constructor of the Drawing class
        /// </summary>
        public Drawing(){
            _background = Color.RGBColor(1, 2, 16);
            _bullets = new List<Bullet>();
            _enemies = new List<EnemyAdapter>();
            _stars = new List<Star>();
            _ship = new Spaceship();
            _random = new Random();
        }

        /// <summary>
        /// This property returns the list of stars to that will be drawn to the game window during gameplay
        /// </summary>
        /// <value></value>
        public List<Star> Stars{
            get{return _stars;}
            set{_stars = value;}
        }

        /// <summary>
        /// This property returns the list of bullets that will be drawn to the game window
        /// </summary>
        /// <value></value>
        public List<Bullet> Bullets{
            get {return _bullets;}
        }

        /// <summary>
        /// This property returns the list of enemies that will be drawn to the game window
        /// </summary>
        /// <value></value>
        public List<EnemyAdapter> Enemies{
            get {return _enemies;}
        }

        /// <summary>
        /// This property returns the spaceship that will be drawn to the game window
        /// </summary>
        /// <value></value>
        public Spaceship Ship{
            get{return _ship;}
            set{_ship = value;}
        }

        /// <summary>
        /// This method generates stars
        /// </summary>
        public void GenerateStars (){
            Bitmap _star = new Bitmap("star_1", "images/star_1.png");

            int type = _random.Next(1, 3);
            if(type == 2){
                _star = new Bitmap("star_2", "images/star_2.png");
            }

            Star star = new Star(_star);

            int rng = _random.Next(1, 11);
            if(_stars.Count < 50 && rng == 10){
                _stars.Add(star);
            }
        }

        /// <summary>
        /// This method removes a star from the list of stars if the star moves out of bounds
        /// </summary>
        public void RemoveStars(){
            for(int i = 0; i < _stars.Count; i ++){
                if(_stars[i].Y > 750){
                    _stars.Remove(_stars[i]);
                }
            }
        }

        /// <summary>
        /// This method removes an enemy from the list of enemies if the enemy moves out of bounds
        /// </summary>
        public void CheckIfRemoveEnemy(){
            for(int i = 0; i < _enemies.Count; i ++){
                if(_enemies[i].ReturnEnemy.x < 0 || _enemies[i].ReturnEnemy.x > 1400 || _enemies[i].ReturnEnemy.y > 750){
                    _enemies.Remove(_enemies[i]);
                }
            }
        }

        /// <summary>
        /// This method removes a bullet from the list of bullets if the bullet moves out of bounds
        /// </summary>
        public void CheckIfRemoveBullet(){
            for(int i = 0; i < _bullets.Count; i ++){
                if(_bullets[i].Y < 0){
                    _bullets.Remove(_bullets[i]);
                }
            }
        }

        /// <summary>
        /// This method draws all the necessary elements to the game window during gameplay
        /// </summary>
        /// <param name="window"></param>
        /// <param name="level"></param>
        public void Draw(Window window, int level){

            SplashKit.ClearScreen(_background);

            if(level != 4){
                 GenerateStars();

                foreach(Star s in _stars){
                    s.Draw(window);
                    s.Move();
                }
                RemoveStars();
                _ship.DrawLives(window);
                _ship.Move();
            }
            else if(level == 4){
                Bitmap background = new Bitmap("finalBG", "finalBG.png");
                _ship.Ship = new Bitmap("finalgun", "finalgun.png");
                window.DrawBitmap(background, 0, 0);
            }

            foreach(Bullet b in _bullets){
                b.Draw(window);
                b.Move();
            }

            foreach(EnemyAdapter e in _enemies){
                e.Draw(window);
                e.Move();
            }
            _ship.Draw(window);
            
        }

        /// <summary>
        /// This method asks the spaceship to create a bullet. It will be called by a method in the LevelMaster class
        /// </summary>
        public void Shoot(){
            _ship.createBullet(_bullets);
        }

        /// <summary>
        /// This method asks its list of bullets to check if any of its bullets have collided with any enemies and performs actions based on the answer
        /// </summary>
        /// <param name="p"></param>
        public void Collision(LevelMaster p){

            Enemy currentEnemy;
            EnemyAdapter currentAdapter;
            for(int e = 0; e < _enemies.Count; e ++){

                currentEnemy = _enemies[e].ReturnEnemy;
                currentAdapter = _enemies[e];

                for(int i = 0; i < _bullets.Count; i ++){
                    if(_bullets[i].CheckIfCollide(currentEnemy)){
                        SplashKit.PlaySoundEffect("sounds/impact.mp3", 1, (float)0.2);
                        _enemies.Remove(currentAdapter);
                        _bullets.Remove(_bullets[i]);
                        p.Collided();
                    }
                }
            }
            
        }

        /// <summary>
        /// This method checks to see if the spaceship has been hit by any of the enemies in the list of enemies and if so, returns the type of enemy it has been hit by
        /// </summary>
        /// <returns></returns>
        public Type Hit(){
            Type type = Type.asteroid;
            for(int i = 0; i < _enemies.Count; i ++){
                Enemy currentEnemy = _enemies[i].ReturnEnemy;
                EnemyAdapter currentAdapter = _enemies[i];

                if(_ship.CheckIfHit(currentEnemy)){
                    _enemies.Remove(currentAdapter);
                    SplashKit.PlaySoundEffect("sounds/hit.mp3", 1, (float)0.4);
                    _ship.Lives -= 1;
                    type = currentEnemy.Type;
                }
            }
            return type;
        }
    }
}