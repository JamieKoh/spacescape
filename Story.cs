using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace CustomProgram{

    /// <summary>
    /// This is the Story class. It deals with drawing all the screens that are not the main gameplay
    /// </summary>
    public class Story{

        private int slideLimit;
        private int slide;
        private Bitmap bg;
        private Bitmap p256;
        private Bitmap Monpai;

        /// <summary>
        /// This is the class constructor that accepts values
        /// </summary>
        /// <param name="level"></param>
        /// <param name="goal"></param>
        public Story(int level, int goal){
            bg = new Bitmap("shipBG", "images/shipBG.png");
            p256 = new Bitmap("p256_1", "images/P256_1.png");
            Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
            slideLimit = 2;
            slide = 1;
        }

        /// <summary>
        /// This is the default class constructor
        /// </summary>
        public Story():this(1, 10){}

        /// <summary>
        /// This method draws the main cutscenes before nd in between levels
        /// </summary>
        /// <param name="window"></param>
        /// <param name="level"></param>
        /// <param name="gameStart"></param>
        public void Draw(Window window, int level, Boolean gameStart){
            

            if(level == 0){
                slideLimit = 22;
            }
            else if(level == 1){
                slideLimit = 8;
            }
            else if(level == 2){
                slideLimit = 9;
            }
            else if(level == 3){
                slideLimit = 16;
            }
            
            do{
                if(SplashKit.MusicPlaying() == false){
                Music cutscene = new Music("cutscene", "sounds/cutscene.mp3");
                    SplashKit.PlayMusic(cutscene, 1, (float)0.5);
                }
                SplashKit.ClearScreen(Color.Black);
                
                string dialogue = "AHHHHH WHAT ARE YOU!?";
                string next = "Click anywhere to continue or S to skip";

                if(level == 0){
                    if(slide == 1){
                        bg = new Bitmap("prison", "images/prison.png");
                        dialogue = "Alien commander: What is the issue corporal?";
                        p256 = new Bitmap("soldier_commander", "images/soldier_commander.png");
                        window.DrawBitmap(bg, 0, 0);;
                        window.DrawBitmap(p256, 0, 750 - p256.Height);
                        Monpai = new Bitmap("soldier_2", "images/soldier_2.png");
                        window.DrawBitmap(Monpai, 1400 - Monpai.Width, 750 - Monpai.Height);
                        window.DrawBitmap(Monpai, 1420 - Monpai.Width*2, 750 - Monpai.Height);
                        Monpai = new Bitmap("soldier_1", "images/soldier_1.png");
                        window.DrawBitmap(Monpai, 1440 - Monpai.Width*3, 750 - Monpai.Height);
                    }
                    else if(slide == 2){
                        bg = new Bitmap("prison", "images/prison.png");
                        dialogue = "Alien soldier: Commander! It's unbelieveble - crazy! One of the female humans has gone missing. We're searching all the places she's likely to be now.";
                        p256 = new Bitmap("soldier_commander", "images/soldier_commander.png");
                        Monpai = new Bitmap("soldier_2", "images/soldier_2.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 200, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1200 - Monpai.Width, 750 - Monpai.Height);
                        window.DrawBitmap(Monpai, 1220 - Monpai.Width*2, 750 - Monpai.Height);
                        Monpai = new Bitmap("soldier_1", "images/soldier_1.png");
                        window.DrawBitmap(Monpai, 1240 - Monpai.Width*3, 750 - Monpai.Height);
                    }
                    else if(slide == 3){
                        dialogue = "Prisoner 256: AHHHHH WHAT ARE YOU!?";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        p256 = new Bitmap("p256_1", "images/p256_1.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 0, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 4){
                        dialogue = "Alien soldier: Wait! There! I heard something from the emergency ship!";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        p256 = new Bitmap("p256_2", "images/p256_2.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 100, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 5){
                        dialogue = "Alien soldier 2: How did a human even manage to get to it!?";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        p256 = new Bitmap("p256_3", "images/p256_3.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 100, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 6){
                        dialogue = "Alien creature: Run run run....";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        p256 = new Bitmap("p256_3", "images/p256_3.png");
                        Monpai = new Bitmap("Monpai_3", "images/Monpai_3.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 100, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1400 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 7){
                        dialogue = "Alien creature: Run run run....";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        p256 = new Bitmap("p256_3", "images/p256_3.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 400, 750 - p256.Height);
                    }
                    else if(slide == 8){
                        dialogue = "";
                        SplashKit.DrawText("You manage to escape the alien soldiers.....", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 20, 520, 340);
                    }
                    else if(slide == 9){
                        dialogue = "Alien soldier: What do we do commander? A prisoner has actually escaped....";
                        bg = new Bitmap("escapeBG", "images/escapeBG.png");
                        p256 = new Bitmap("soldier_commander", "images/soldier_commander.png");
                        Monpai = new Bitmap("soldier_2", "images/soldier_2.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 200, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1200 - Monpai.Width, 750 - Monpai.Height);
                        window.DrawBitmap(Monpai, 1220 - Monpai.Width*2, 750 - Monpai.Height);
                        Monpai = new Bitmap("soldier_1", "images/soldier_1.png");
                        window.DrawBitmap(Monpai, 1240 - Monpai.Width*3, 750 - Monpai.Height);
                    }
                    else if(slide == 10){
                        dialogue = "Alien commander: She won't get far. The asteroid fields nearby will crush that ship";
                        bg = new Bitmap("escapeBG", "images/escapeBG.png");
                        p256 = new Bitmap("soldier_commander", "images/soldier_commander.png");
                        Monpai = new Bitmap("soldier_2", "images/soldier_2.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 200, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1200 - Monpai.Width, 750 - Monpai.Height);
                        window.DrawBitmap(Monpai, 1220 - Monpai.Width*2, 750 - Monpai.Height);
                        Monpai = new Bitmap("soldier_1", "images/soldier_1.png");
                        window.DrawBitmap(Monpai, 1240 - Monpai.Width*3, 750 - Monpai.Height);
                    }
                    else if(slide == 11){
                        dialogue = "Prisoner 256: Phewh. I did it....";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        p256 = new Bitmap("p256_3", "images/p256_3.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 200, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1400 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 12){
                        dialogue = "Alien creature: Yay yay yay";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        p256 = new Bitmap("p256_3", "images/p256_3.png");
                        Monpai = new Bitmap("Monpai_2", "images/Monpai_2.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 200, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 800 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 13){
                        dialogue = "Prisoner 256: AHHHHH GET AWAY! WHAT ARE YOU!?";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        p256 = new Bitmap("p256_1", "images/p256_1.png");
                        Monpai = new Bitmap("Monpai_2", "images/Monpai_2.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 0, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 800 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 14){
                        dialogue = "Alien creature: Monpai Monpai Monpai!";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        p256 = new Bitmap("p256_3", "images/p256_3.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 0, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 800 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 15){
                        dialogue = "";
                        SplashKit.DrawText("The alien creature slowly explains that it is an experiment known as Monpai and does not appear to be hostile. Suddenly, Monpai starts frantically running around.", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 20, 30, 340);
                    }
                    else if(slide == 16){
                        dialogue = "Monpai: ROCK ROCK ROCK!";
                        bg = new Bitmap("ship_asteroidBG", "images/ship_asteroidBG.png");
                        p256 = new Bitmap("p256_4", "images/p256_4.png");
                        Monpai = new Bitmap("Monpai_3", "images/Monpai_3.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 0, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 800 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 17){
                        dialogue = "Prisoner 256: What?";
                        bg = new Bitmap("ship_asteroidBG", "images/ship_asteroidBG.png");
                        p256 = new Bitmap("p256_4", "images/p256_4.png");
                        Monpai = new Bitmap("Monpai_2", "images/Monpai_2.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 0, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1400 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 18){
                        dialogue = "Monpai: ROCK ROCK ROCK!";
                        bg = new Bitmap("ship_asteroidBG", "images/ship_asteroidBG.png");
                        p256 = new Bitmap("p256_4", "images/p256_4.png");
                        Monpai = new Bitmap("Monpai_3", "images/Monpai_3.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 0, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 800 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 19){
                        dialogue = "Prisoner 256: Wha- OH NO ASTEROID FIELD! WHAT DO WE DO? I DIDN'T PLAN THIS FAR! I DIDN'T EVEN THINK I'D MAKE IT THIS FAR!";
                        bg = new Bitmap("ship_asteroidBG", "images/ship_asteroidBG.png");
                        p256 = new Bitmap("p256_1", "images/p256_1.png");
                        Monpai = new Bitmap("Monpai_2", "images/Monpai_2.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 0, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1400 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 20){
                        dialogue = "Monpai: SHOOT SHOOT SHOOT!";
                        bg = new Bitmap("ship_asteroidBG", "images/ship_asteroidBG.png");
                        p256 = new Bitmap("p256_1", "images/p256_1.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(bg, 0, 0);
                        window.DrawBitmap(p256, 0, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 800 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 21){
                        dialogue = "";
                        next = "";
                        SplashKit.DrawText("Use the left and right arrow keys to move", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 20, 520, 340);
                        SplashKit.DrawText("Press the space bar to shoot", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 20, 580, 370);
                    }
                }
                else if(level == 1){
                    if(slide == 1){
                        dialogue = "Monpai: Yay yay yay";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_9", "images/p256_9.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 2){
                        dialogue = "Prisoner 256: *Sigh* We actually made it out of there...";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_5", "images/p256_5.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 3){
                        dialogue = "Monpai: Earth earth earth?";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_5", "images/p256_5.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 4){
                        dialogue = "Prisoner 256: yeah... we're going to earth";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_6", "images/p256_6.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 5){
                        dialogue = "";
                        SplashKit.DrawText("You and Monpai continue cruising through space for a few days until...", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 20, 430, 340);
                    }
                    else if(slide == 6){
                        dialogue = "Prisoner 256: Monpai, look! What are those!?";
                        bg = new Bitmap("ship_debrisMitesBG", "images/ship_debrisMitesBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_1", "images/p256_1.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 7){
                        dialogue = "Monpai: Debris Mites Debris Mites Debris Mites! Shoot shoot shoot!";
                        bg = new Bitmap("ship_debrisMitesBG", "images/ship_debrisMitesBG.png");
                        next = "";
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_9", "images/p256_9.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                }
                else if(level == 2){
                    if(slide == 1){
                        dialogue = "Monpai: Yay yay yay! 256 256 256!";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_6", "images/p256_6.png");
                        Monpai = new Bitmap("Monpai_2", "images/Monpai_2.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 2){
                        dialogue = "Prisoner 256: Actually Monpai, my real name is Artemis";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_6", "images/p256_6.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 3){
                        dialogue = "Monpai: Artemis Artemis Artemis!";
                        bg = new Bitmap("shipBG", "images/shipBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_6", "images/p256_6.png");
                        Monpai = new Bitmap("Monpai_2", "images/Monpai_2.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 4){
                        dialogue = "";
                        SplashKit.DrawText("You and Monpai continue confidently cruising through space for a few more days until...", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 20, 400, 340);
                    }
                    else if(slide == 5){
                        dialogue = "Monpai: Ambush ambush ambush!";
                        bg = new Bitmap("ship_holdiansBG", "images/ship_holdiansBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_6", "images/p256_6.png");
                        Monpai = new Bitmap("Monpai_2", "images/Monpai_2.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 6){
                        dialogue = "Artemis: Huh-";
                        bg = new Bitmap("ship_holdiansBG", "images/ship_holdiansBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_4", "images/p256_4.png");
                        Monpai = new Bitmap("Monpai_2", "images/Monpai_2.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 7){
                        dialogue = "Artemis: WHAT THE- ARE THOSE HOLDIANS CONTROLLING DEBRIS MITES!?";
                        bg = new Bitmap("ship_holdiansBG", "images/ship_holdiansBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_1", "images/p256_1.png");
                        Monpai = new Bitmap("Monpai_3", "images/Monpai_3.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 8){
                        dialogue = "Monpai: Shoot shoot shoot!";
                        next = "";
                        bg = new Bitmap("ship_holdiansBG", "images/ship_holdiansBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_9", "images/p256_9.png");
                        Monpai = new Bitmap("Monpai_3", "images/Monpai_3.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                }
                else if(level == 3){
                    if(slide == 1){
                        dialogue = "Artemis: Look Monpai! I can see earth! There it is!";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_7", "images/p256_7.png");
                        Monpai = new Bitmap("Monpai_2", "images/Monpai_2.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 2){
                        dialogue = "Monpai: Yay yay yay!";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_7", "images/p256_7.png");
                        Monpai = new Bitmap("Monpai_3", "images/Monpai_3.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1200 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 3){
                        dialogue = "Monpai: Yay yay yay!";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_7", "images/p256_7.png");
                        Monpai = new Bitmap("Monpai_2", "images/Monpai_2.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 4){
                        dialogue = "Monpai: Yay yay yay!";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_7", "images/p256_7.png");
                        Monpai = new Bitmap("Monpai_2", "images/Monpai_2.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 5){
                        dialogue = "Monpai: Miss miss miss.";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_6", "images/p256_6.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 6){
                        dialogue = "Artemis: Miss what Monpai? We got them all didn't we?";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_6", "images/p256_6.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 7){
                        dialogue = "Monpai: Monpai Monpai Monpai.";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_6", "images/p256_6.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 8){
                        dialogue = "Artemis: Huh? Oh! No, Monpai. I'm not going to leave you behind. You're coming with me.";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_6", "images/p256_6.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 900 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 9){
                        dialogue = "Monpai: No no no. Can't can't can't...";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_5", "images/p256_5.png");
                        Monpai = new Bitmap("Monpai_3", "images/Monpai_3.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 10){
                        dialogue = "Artemis: What do you mean can't? Sure we'll be fugitives but we made it this far.";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_5", "images/p256_5.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 11){
                        dialogue = "Monpai: Suffocate suffocate suffocate..... Shoot shoot shoot.";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_5", "images/p256_5.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 12){
                        dialogue = "Artemis: Shoot? What? Who? You? Monpai! I can't shoot you!";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_8", "images/p256_8.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 13){
                        dialogue = "Monpai: Please please please?";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_8", "images/p256_8.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 300, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 14){
                        dialogue = "Artemis: B-but we made it this far.... no... why- you mean- you knew you'd- then why did you come along if you knew you were going to- ???";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_8", "images/p256_8.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 200, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                    else if(slide == 15){
                        dialogue = "Monpai: Free free free. Happy happy happy. Friend friend friend. Please please please?";
                        next = "";
                        bg = new Bitmap("ship_earthBG", "images/ship_earthBG.png");
                        window.DrawBitmap(bg, 0, 0);
                        p256 = new Bitmap("p256_8", "images/p256_8.png");
                        Monpai = new Bitmap("Monpai_1", "images/Monpai_1.png");
                        window.DrawBitmap(p256, 200, 750 - p256.Height);
                        window.DrawBitmap(Monpai, 1100 - Monpai.Width, 750 - Monpai.Height);
                    }
                }
                
                SplashKit.FillRectangle(Color.RGBAColor(0, 0, 0, 0.6), 0, 600, 1400, 150);
                SplashKit.DrawText(dialogue, Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 20, 40, 640);
                SplashKit.DrawText(next, Color.White, "fonts/coolvetica rg.ttf", 15, 580, 710);
                if(slide == slideLimit - 1){
                    SplashKit.DrawText("Click anywhere to begin", Color.White, "fonts/coolvetica rg.ttf", 15, 630, 710);
                    
                }

                if(SplashKit.MouseClicked(MouseButton.LeftButton) && slide < slideLimit){
                    slide += 1;
                }

                if(SplashKit.KeyTyped(KeyCode.SKey)){
                    slide = slideLimit - 1;
                }

                SplashKit.RefreshScreen(60);

                SplashKit.ProcessEvents();

            }while(slide < slideLimit && SplashKit.QuitRequested() != true && gameStart == false);

        }

        /// <summary>
        /// This method draws the screen informing th player that they have failed the level
        /// </summary>
        /// <param name="gameStart"></param>
        /// <param name="doom"></param>
        public void DrawFail(Boolean gameStart, Type doom){
            do{
                
                string reason = "You got hit by an asteroid";

                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawText("Level Failed", Color.WhiteSmoke, "fonts/Vampire Wars.ttf", 100, 410, 250);
                SplashKit.DrawText("Click anywhere to try again", Color.White, "fonts/coolvetica rg.ttf", 20, 570, 650);

                if(doom == Type.Holdians){
                    reason = "You got crashed into a Holdian!";
                    SplashKit.DrawText(reason, Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 415, 400);
                }
                else if(doom == Type.debrisMites){
                    reason = "You got attacked by a Debris Mite!";
                    SplashKit.DrawText(reason, Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 410, 400);
                }
                else if(doom == Type.asteroid){
                    SplashKit.DrawText(reason, Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 470, 400);
                }
                else if(doom == Type.Monpai){
                    reason = "Monpai is waiting for you to shoot.";
                    SplashKit.DrawText(reason, Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 410, 400);
                }

                SplashKit.RefreshScreen(60);
                if(SplashKit.MouseClicked(MouseButton.LeftButton) && slide < slideLimit){
                    gameStart = false;
                }
                SplashKit.ProcessEvents();

            }while(SplashKit.QuitRequested() != true && gameStart == true);
        }

        /// <summary>
        /// This method draws the screen informing th player that they have passed the level
        /// </summary>
        /// <param name="gameStart"></param>
        /// <param name="level"></param>
        public void DrawPass(Boolean gameStart, int level){
            do{
                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawText("Level Passed", Color.WhiteSmoke, "fonts/Vampire Wars.ttf", 100, 410, 200);
                if(level == 1){
                    SplashKit.DrawText("Congratulations. You and Monpai have somehow managed to survive", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 120, 390);
                    SplashKit.DrawText("another day", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 600, 430);
                }
                else if(level == 2){
                    SplashKit.DrawText("It seems you have gained the gods' favor and have been permitted to", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 120, 390);
                    SplashKit.DrawText("live another day", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 550, 430);
                }
                else if(level == 3){
                    SplashKit.DrawText("The journey has been long and chaotic but you have somehow made it", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 120, 390);
                    SplashKit.DrawText("this far..", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 600, 430);
                }
                else if(level == 4){
                    if(SplashKit.MusicPlaying() == false){
                        SplashKit.DrawText("Congratulations. You have made it back to earth ..... alone", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 200, 390);
                    }
                }
                SplashKit.DrawText("Click anywhere to continue", Color.White, "fonts/coolvetica rg.ttf", 15, 630, 710);

                SplashKit.RefreshScreen(60);

                if(SplashKit.MouseClicked(MouseButton.LeftButton) && slide < slideLimit){
                    gameStart = false;
                }

                SplashKit.ProcessEvents();

            }while(SplashKit.QuitRequested() != true && gameStart == true);
        }

        /// <summary>
        /// This method draws the final screen of the game
        /// </summary>
        /// <param name="window"></param>
        /// <param name="newDrawing"></param>
        /// <param name="stars"></param>
        public void DrawEnd(Window window, Drawing newDrawing, List<Star> stars){

            SplashKit.ClearScreen(Color.Black);

            foreach(Star s in stars){
                s.Draw(window);
                s.Move();
            }
            SplashKit.DrawText("Game over", Color.White, "fonts/Vampire Wars.ttf", 100, 420, 200);
            SplashKit.DrawText("Click anywhere to exit", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 20, 620, 390);
            SplashKit.RefreshScreen(60);

        }

        /// <summary>
        /// This method draws the first screen of the game
        /// </summary>
        /// <param name="window"></param>
        /// <param name="newDrawing"></param>
        /// <param name="stars"></param>
        public void DrawStart(Window window, Drawing newDrawing, List<Star> stars){
            if(SplashKit.MusicPlaying() == false){
                Music intro = new Music("intro", "sounds/intro.mp3");
                SplashKit.PlayMusic(intro, 1, (float)0.5);
            }
            SplashKit.ClearScreen(Color.Black);

            foreach(Star s in stars){
                s.Draw(window);
                s.Move();
            }
            SplashKit.DrawText("SPACESCAPE", Color.White, "fonts/Vampire Wars.ttf", 100, 410, 200);
            SplashKit.DrawText("Press space to begin", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 20, 620, 390);
            SplashKit.DrawText("by Jamie Jasmine Koh (101233988)", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 15, 620, 720);
            SplashKit.RefreshScreen(60);
        }

        /// <summary>
        /// This method draws the moving text that explains the backstory of the game after the start screen
        /// </summary>
        /// <param name="window"></param>
        /// <param name="newDrawing"></param>
        /// <param name="stars"></param>
        /// <param name="position"></param>
        public void DrawIntro(Window window, Drawing newDrawing, List<Star> stars, float position){
            
            SplashKit.ClearScreen(Color.Black);

            foreach(Star s in stars){
                s.Draw(window);
                s.Move();
            }
            SplashKit.FillRectangle(Color.Black, 0, position, 1400, 235);
            SplashKit.DrawText("In the year 3050, humans send  criminals to a prison facility of an otherwise", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 60, position);
            SplashKit.DrawText("uninhabitted planet. Except.... it's not as uninhabitted as everyone thinks. In ", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 60, position + 45);
            SplashKit.DrawText("fact, the prison is actually a huge lab for an advanced alien species and all the", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 60, position + 90);
            SplashKit.DrawText("prisoners (which include other aliens) are their test subjects. Alone on an alien ", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 60, position + 135);
            SplashKit.DrawText("planet, a lone human is making plans and preparations for an escape back to", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 60, position + 180);
            SplashKit.DrawText("Earth.", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 40, 60, position + 235);
            if(position < 300){
                SplashKit.DrawText("Press space to begin", Color.WhiteSmoke, "fonts/coolvetica rg.ttf", 20, 620, 700);
            }
            SplashKit.RefreshScreen(60);
        }
    }
}