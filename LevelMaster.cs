using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace CustomProgram{

    /// <summary>
    /// This is the LevelMaster class
    /// </summary>
    public class LevelMaster{

        private Random enemyGenerator;
        private Random enemyPosition;
        private Random disperse;
        private int _goal;
        private int _level;
        private int _defeated;

        /// <summary>
        /// This is the class constructor that accepts values
        /// </summary>
        /// <param name="level"></param>
        public LevelMaster(int level){
            enemyGenerator = new Random();
            enemyPosition = new Random();
            disperse = new Random();
            _level = level;
            _goal = 10;
            _defeated = 0;
        }

        /// <summary>
        /// This is the default class constructor
        /// </summary>
        public LevelMaster():this(0){}

        /// <summary>
        /// This is the property that returns the _level attribute
        /// </summary>
        /// <value></value>
        public int Level{
            get{return _level;}
            set{_level = value;}
        }

        /// <summary>
        /// This is the property that returns the _defeated attribute
        /// </summary>
        /// <value></value>
        public int Defeated{
            get{return _defeated;}
            set{_defeated = value;}
        }

        /// <summary>
        /// This is the property that returns the _goal attribute
        /// </summary>
        /// <value></value>
        public int Goal{
            get{return _goal;}
            set{_goal = value;}
        }

        /// <summary>
        /// This method increases the _defeated attribute by 1 every time a bullet hits an enemy
        /// </summary>
        public void Collided(){
            _defeated += 1;
        }

        /// <summary>
        /// This method generates different enemies based on the _level attribute
        /// </summary>
        /// <param name="enemies"></param>
        public void GenerateEnemy (List<EnemyAdapter> enemies){
            if(_defeated < _goal){
                
                Type type = Type.asteroid;
                Bitmap enemy = new Bitmap("asteroid", "images/asteroid.png");
                int xbarrier = 1400 - enemy.Width;

                int rng2 = enemyPosition.Next(0, xbarrier);

                int rng3 = disperse.Next(0, 10);

                if(_level == 1 && enemies.Count < 10 && rng3 == 9){
                    Enemy newEnemy = new Enemy(rng2, enemy, type);
                    EnemyAdapter newAdapter = new EnemyAdapter(newEnemy, 1);
                    enemies.Add(newAdapter);
                }
                else if(_level == 2 && enemies.Count < 10 && rng3 == 9){
                    int rng = enemyGenerator.Next(1, 3);

                    if(rng == 1){
                        enemy = new Bitmap("asteroid", "images/asteroid.png");
                        type = Type.asteroid;
                    }
                    else{
                        enemy = new Bitmap("flyingalien", "images/flyingalien.png");
                        type = Type.debrisMites;
                    }

                    Enemy newEnemy = new Enemy(rng2, enemy, type);
                    EnemyAdapter newAdapter = new EnemyAdapter(newEnemy, 2);
                    enemies.Add(newAdapter);
                        
                }
                else if(_level == 3 && enemies.Count < 20 && rng3 == 9){
                    int rng = enemyGenerator.Next(1, 4);

                    if(rng == 1){
                        enemy = new Bitmap("asteroid", "images/asteroid.png");
                        type = Type.asteroid;
                    }
                    else if(rng == 2){
                        enemy = new Bitmap("flyingalien", "images/flyingalien.png");
                        type = Type.debrisMites;
                    }
                    else if(rng == 3){
                        enemy = new Bitmap("aliendriver", "images/aliendriver.png");
                        type = Type.Holdians;
                    }

                    Enemy newEnemy = new Enemy(rng2, enemy, type);
                    EnemyAdapter newAdapter = new EnemyAdapter(newEnemy, 3);
                    enemies.Add(newAdapter);
                }
                else if(_level == 4 && enemies.Count < 1){
                    enemy = new Bitmap("Monpai_final", "Monpai_final.png");
                    Enemy newEnemy = new Enemy((1500 - enemy.Width)/2, enemy, Type.Monpai);
                    newEnemy.y = 750/2;
                    EnemyAdapter newAdapter = new EnemyAdapter(newEnemy, 4);
                    enemies.Add(newAdapter);
                }
            }
        }

        /// <summary>
        /// This method checks to see if the user indicates that they want to shoot a bullet and if so, it calls the Shoot method from the Drawing class
        /// </summary>
        /// <param name="myDrawing"></param>
        public void Shoot(Drawing myDrawing){
            if(SplashKit.KeyTyped(KeyCode.SpaceKey)){
                SplashKit.PlaySoundEffect("sounds/shoot.mp3", 1, (float)0.7);
                myDrawing.Shoot();
            }
        }
        
        /// <summary>
        /// This method is called before or in between levels and will in turn call the Draw method from the Story class
        /// </summary>
        /// <param name="window"></param>
        /// <param name="gameStart"></param>
        public void Cutscene(Window window, Boolean gameStart){
            Story currentStory = new Story(_level, _goal);
            currentStory.Draw(window, _level, gameStart);
        }

        /// <summary>
        /// This method is called if the player fails a level and will in turn call the DrawFail method from the Story class
        /// </summary>
        /// <param name="gameStart"></param>
        /// <param name="doom"></param>
        public void Fail(Boolean gameStart, Type doom){
            Story currentStory = new Story(_level, _goal);
            currentStory.DrawFail(gameStart, doom);
        }

        /// <summary>
        /// This method is called if the player passes a level and will in turn call the DrawPass method from the Story class
        /// </summary>
        /// <param name="gameStart"></param>
        public void Pass(Boolean gameStart){
            Story currentStory = new Story(_level, _goal);
            currentStory.DrawPass(gameStart, _level);
        }

        /// <summary>
        /// This method sets the _goal attribute based on the _level attribute
        /// </summary>
        public void SetGoal(){
            if(_level == 1){
                _goal = 10;
            }
            else if(_level == 2){
                _goal = 20;
            }
            else if(_level == 3){
                _goal = 30;
            }
            else if(_level == 4){
                _goal = 1;
            }
        }

        /// <summary>
        /// This method is called after the player completes the game and will in turn call the DrawEnd method from the Story class
        /// </summary>
        /// <param name="window"></param>
        /// <param name="newDrawing"></param>
        /// <param name="stars"></param>
        public void DrawEnd(Window window, Drawing newDrawing, List<Star> stars){
            Story currentStory = new Story(_level, _goal);
            currentStory.DrawEnd(window, newDrawing, stars);
        }

        /// <summary>
        /// This method is called when the game is first run and will in turn call the DrawStart method from the Story class
        /// </summary>
        /// <param name="window"></param>
        /// <param name="newDrawing"></param>
        /// <param name="stars"></param>
        public void DrawStart(Window window, Drawing newDrawing, List<Star> stars){
            Story currentStory = new Story(_level, _goal);
            currentStory.DrawStart(window, newDrawing, stars);
        }

        /// <summary>
        /// This method is called after the Start screen and introduces the player to the backstory of the game and will in turn call the DrawIntro method from the Story class
        /// </summary>
        /// <param name="window"></param>
        /// <param name="newDrawing"></param>
        /// <param name="stars"></param>
        /// <param name="position"></param>
        public void DrawIntro(Window window, Drawing newDrawing, List<Star> stars, float position){
            Story currentStory = new Story(_level, _goal);
            currentStory.DrawIntro(window, newDrawing, stars, position);
        }

    }
}