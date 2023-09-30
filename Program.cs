using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class Program
    {
        public static void Main()
        {
            Window gameWindow = new Window("GameMain", 1400, 750);
                
            Drawing myDrawing = new Drawing();
            LevelMaster currentLevel = new LevelMaster();

            //All these are to control the entering and exiting of loops
            Boolean gameStart = false;
            Boolean gameend = false;
            Boolean Pause = false;
            Boolean close = false;
            Boolean startup = true;
            Boolean intro  = true;

            //To make sure to ready the audio files for use in the game
            SplashKit.OpenAudio();

            //This is the main loop that will run as long as the game has not ended and is not closed
            do{

                //This is to execute the codes for the opening page
                if(startup == true){
                    Drawing newDrawing = new Drawing();
                    do{
                        newDrawing.GenerateStars();
                        currentLevel.DrawStart(gameWindow, newDrawing, newDrawing.Stars);
                        SplashKit.ProcessEvents();

                        //This loop is to set the startup to false so that when the main loop is entered, the program will skip over the opening screen codes since startup is set to false
                        if(SplashKit.KeyTyped(KeyCode.SpaceKey)){
                            startup = false;
                        }
                        newDrawing.RemoveStars();
                    }while(SplashKit.QuitRequested() != true && startup == true);
                }

                //This is to execute the codes for the intro
                if(intro == true){
                    Drawing newDrawing = new Drawing();

                    //This variable is used to control the initial y position of the text inside the loop before it starts moving.
                    float position = 750;
                    do{
                        newDrawing.GenerateStars();
                        currentLevel.DrawIntro(gameWindow, newDrawing, newDrawing.Stars, position);
                        position -= (float)0.5;
                        SplashKit.ProcessEvents();

                        //This is to stop the execution of the intro page codes
                        if(SplashKit.KeyTyped(KeyCode.SpaceKey)){
                            intro = false;
                            SplashKit.StopMusic();
                        }
                        newDrawing.RemoveStars();
                    }while(SplashKit.QuitRequested() != true && intro == true);
                }

                /// <summary>
                /// This loop is executed after the intro and the game begins. Before every level, there is a cutscene that plays
                /// </summary>
                /// <value></value>
                do{
                    //This is to initiate cutscenes at the start of the game
                    //Level 4 is the last level of the game so there are no cutscenes at the end of that level
                    if(currentLevel.Level != 4){
                        
                        //To stop any music currently playing because the background music of the cutscenes will only play if there is no other music playing
                        SplashKit.StopMusic();
                        currentLevel.Cutscene(gameWindow, gameStart);
                        
                        SplashKit.StopMusic();

                        //This updates the variables to control the loops so that the next do loop will be executed
                        gameStart = true;
                        Pause = false;

                        //Increases the level of the game after the cutscenes so that all the codes will adjust themselves to execute the next level of gameplay after the cutscenes
                        currentLevel.Level += 1;

                        //Reset the number of lives at the end of each cutscene so that when the next level begins, the number of lives will always be 3
                        myDrawing.Ship.Lives = 3;
                        
                    }

                    //Reset the number of defeated enemies so that each new level starts with no enemies being defeated. This prevents the number of defeated enemies to carry over to the next level and make it easier.
                    currentLevel.Defeated = 0;
                    
                    SplashKit.RefreshScreen(60);

                    //To control the repetition of music later
                    int count = 1;

                    //Default value of a variable used later in the event that the user fails
                    Type doom = Type.asteroid;

                    //Set the number of enemies that need to be defeated at the start of every new level
                    currentLevel.SetGoal();

                        /// <summary>
                        /// This loop controls the main gameplay of the game
                        /// </summary>
                        /// <value></value>
                        do{
                            
                            //When the level begins, if there is no music playing (which there should not be because the music from the cutscenes was stopped after the end of the cutscenes), then the gameplay music will play. This means that every time the song ends, it will repeat again
                            if(SplashKit.MusicPlaying() == false && close == false && currentLevel.Level != 4){
                                Music mainMusic = new Music("mainMusic", "sounds/mainMusic.mp3");
                                SplashKit.PlayMusic(mainMusic, 1, (float)0.8);
                            }
                            
                            /// <summary>
                            /// These are the codes that enable the gameplay
                            /// </summary>
                            /// <value></value>
                            if(Pause == false && close == false){
                                myDrawing.Draw(gameWindow, currentLevel.Level);
                                currentLevel.GenerateEnemy(myDrawing.Enemies);
                                currentLevel.Shoot(myDrawing);
                                myDrawing.Collision(currentLevel);
                                myDrawing.CheckIfRemoveEnemy();
                                myDrawing.CheckIfRemoveBullet();
                                if(currentLevel.Level != 4){
                                    doom = myDrawing.Hit();
                                }
                            }
                            
                            /// <summary>
                            /// This loop will be executed if the player fails the level
                            /// </summary>
                            /// <value></value>
                            if(myDrawing.Ship.Lives == 0 && close == false){

                                //Remove everything from the lists so that when the next level starts, it starts with a fresh list
                                myDrawing.Enemies.Clear();
                                myDrawing.Bullets.Clear();
                                myDrawing.Ship = new Spaceship();
                                Pause = true;
                                SplashKit.FreeMusic(new Music("mainMusic", "sounds/mainMusic.mp3"));

                                //This utilizes the count variable from earlier to make sure the sound that plays when the player fails the level will not repeat when it is over like the song of the main gameplay
                                if(SplashKit.MusicPlaying() == false && count == 1){
                                    Music gameOver = SplashKit.LoadMusic("gameOver", "sounds/gameOver.mp3");
                                    SplashKit.PlayMusic(gameOver, 1, (float)0.3);
                                    count += 1;
                                }

                                //Draw the appropriate screen that informs the user that they failed
                                currentLevel.Fail(gameStart, doom);

                                //The final level of the game is a bonus level that is not possible to fail. If for some reason the level is failed, this prevents the cutscene after the passing of level 3 and before the beginning of level 4 from playing again.
                                if(currentLevel.Level != 4){
                                    currentLevel.Level -= 1;
                                }

                                //To leave the do while loop so that the level will not be repeated immediately after the fail screen. Instead, once the loop is left, the cutscenes will be played again
                                gameStart = false;
                            }

                            /// <summary>
                            /// This loop will be excuted if the player defeated enough enemies to pass the level
                            /// </summary>
                            /// <value></value>
                            if(currentLevel.Defeated == currentLevel.Goal){
                                myDrawing.Enemies.Clear();
                                myDrawing.Bullets.Clear();
                                myDrawing.Ship = new Spaceship();
                                Pause = true;
                                SplashKit.FreeMusic(new Music("mainMusic", "sounds/mainMusic.mp3"));
                                if(SplashKit.MusicPlaying() == false && count == 1 && currentLevel.Level != 4){
                                    SplashKit.PlayMusic("sounds/pass.mp3");
                                    count += 1;
                                }

                                //A special loop that is executed when the player passes the final level
                                else if(SplashKit.MusicPlaying() == false && count == 1 && currentLevel.Level == 4){
                                    Music death = new Music("death", "sounds/death2.mp3");
                                    SplashKit.PlayMusic(death, 1, (float)0.5);
                                    
                                    gameend = true;
                                }
                                currentLevel.Pass(gameStart);
                                gameStart = false;
                            }

                            SplashKit.RefreshScreen(60);

                            SplashKit.ProcessEvents();

                        }while(SplashKit.QuitRequested() != true && gameStart == true && close == false);

                            /// <summary>
                            /// The codes that execute after the user passed the final level. It is the screen that tells the user that they have completed the game
                            /// </summary>
                            /// <value></value>
                            if(currentLevel.Level == 4 && close == false){
                                Drawing newDrawing = new Drawing();
                                
                                do{
                                    newDrawing.GenerateStars();
                                    currentLevel.DrawEnd(gameWindow, newDrawing, newDrawing.Stars);
                                    SplashKit.ProcessEvents();
                                    if(SplashKit.MouseClicked(MouseButton.LeftButton)){
                                        //close the whole program
                                        close = true;
                                    }
                                    newDrawing.RemoveStars();
                                }while(SplashKit.QuitRequested() != true && SplashKit.MouseClicked(MouseButton.LeftButton) != true);

                            }

                    SplashKit.ProcessEvents();

                }while(SplashKit.QuitRequested() != true && gameStart == false && close == false);
                
            }while(SplashKit.QuitRequested() != true && gameStart == false && gameend == false && close == false);           
        }
    }
}