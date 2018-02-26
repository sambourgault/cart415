# cart415 - PROCESS JOURNAL
this repo holds sam's attempts to dive into game design.

## Feb 26th, 2018 (suite)

The game is divided in a prelude and an opera.

In the prelude, the player creates AIs by pressing the left button mouse. Inspired by Brian Eno "Music for Airport", a violin note is attached on each of them, creating harmony and disharmony according to the player intensity in spawning new AIs. In this part of the piece, tanks become sound recorders (like their shape already suggests: the two wheels connected by a thread), playing back in loop the note they hold. The prelude ends when the maximum number of tanks has been created, following a predetermined law of this virtual world.

The opera begins the same way, the player spawning two AIs in the video game void. This part of the game is a homage to Steve Reich "Clapping Music" and to Philip Glass first knee play of "Einstein on the Beach". A beat emerges from the collision of the tanks and other game objects in its surroundings, which contain audio from the old TANKS! game, like a twisted memory of how it was before. The two tanks stay synchronized but evolve in a desynchronised way. The rhythm pattern of one tank shifting of one beat every two bars. Collisions also trigger new voices, which describe part of the environment that used to be TANKS!. Until a virtual law strikes again, forcing the game to end.

## Feb 26th, 2018: Thoughts from the last few days

In Steve Reich’s “Pendulum Music”, the interpreters are only there to trigger the piece. They bring a microphone at a certain angle over a speaker and let it go. The mic then oscillate over the speaker creating feedback noise. That’s it, their part is done and gravity takes care of the rest.  
Pendulum Music : https://www.youtube.com/watch?v=fU6qDeJPT-w

A similar logic can be applied to this game. The player is the maestro and decide when the game begins but never when it is gonna end. The player is there to instantiate the tanks by clicking the left mouse button. It might be the easy way to go though..

Updates:
- the people counting is synchronize with the shift in the beat.
- i decided to implement two little games. The first implies AIs falling from a platform that act as "The prelude" of the game. The second one is the two tanks riding side by side, which acts as "The opera".
- the player becomes the maestro of these games.

Still few hours to go..

What’s missing:
- visualization of the shift in beat
- transition between the AI little game
- adding wheel rotation to see that tanks are moving forward


## Feb 22th, 2018: Implementation

I implemented the "Clapping Music" concept on the tank game itself. Maybe a visualization would be helpful because it's not obvious what it's happening.

I still think that this prototype is lacking something. I wonder if the increase of sound intensity that I am thinking of will be enough, if it creates a sense of tension. The first knee in "Einstein on the beach" is thrilling as it succeeds in creating a feeling of unison. One building bloc at a time, the piece becomes more complex. At the beginning, two voices seem to tell random sentences to the public, but as the piece goes by, new voices appear and the whole becomes stronger.  

I guess I should just go for it. For real. Adding progressively new duo of tanks. In term of artificial voice, I already have Alice, George, Jenna. I'm going to add John and Daisy (from http://www.fromtexttospeech.com). Until it is cacophonous. And then! I could take advantage of a mistake I made recently. The objects in the way of the tanks are triggered when tanks pass through them. But if I keep one, the last one, as a solid object (impenetrable) in front of the camera attached to one of the central tanks, the movement of everything else will continue without it. The sound will then vanish as it follows a 3D spatial blend.

**The game becomes this great tanks opera that you did not attend because you got stock on a cube.**

I am also struggling with the absence of interactivity. The only act a player can have on this game is to start it.. More thoughts on that later.

## Feb 21th, 2018: Minimalist music concepts

Process music: same rhythm but one is offset of one beat every four bars. This could be done with the tank, by maybe reusing the tank sound (fire shooting / fire charging/ shell explosion)? The set up that I currently have would be good for such experimentation since it shows two tanks driving forward on a path that resembles a score. Steve Reich's "Clapping Music" is a good example of that concept. And here, a good visualization of that: https://www.youtube.com/watch?v=eu-tRXgOrdg


## Feb 19th, 2018: Still trying out

Ehhh boooy...

I don't know where I am going with that prototype... I'm floating in a world of confusion... Hoping the TANKS! could talk like cats do.

Enumerating the pieces that I find the most compelling within the field of minimalist music and then trying to reuse certain concepts in my TANKS! remake appears as the good way to begin with.

*Experiments on minimalist music: and what it explores*
“It’s gonna rain” Steve Reich: plays with the offset between left and right channels
“4:33” John Cage: plays with the sound created in the surrounding
“I’m sitting in a room” Alvin Lucier: studies the resonance of a room and how his stutter disappears as noise amplifies.
Track two of “Music for Airport” Brian Eno: plays with the offset of six magnetic tapes (similar to Steve Reich "It's gonna rain").
“Pendulum Music” Steve Reich: experiments with feedback between mics and speakers.
"Two Pages" Philip Glass: plays with rhythm and variation in the length of the musical sentences
"Einstein on the beach" Philip Glass: IDEM in the "knees" of the piece.


New attempt:

Mix between offset in stereo and work on rhythm...

Inspired by "Einstein on the Beach", it could be a race between the left and the right stereo output in the Philip Glass way of compositing, using simple rules to create musical sentences evolving in length. Inspired by the Knee Plays in "Einstein by the Beach". The player would hit the element along the way and we would have a glimpse of description.

Maybe I'm going toward a TANKS! opera.. TANKS! in a choir singing to the god of Unity.

## Feb 11th, 2018: Two rough prototypes

Prototype 1: Sound recorder --> Inspired by Steve Reich and Brian Eno pieces experimenting with synchronicity and asynchronicity of multiple sound recorder playing back at slightly different speed, this prototypes explores the visual resemblance of a tank tread tracks and a magnetic tape. Each AI in the game has a specific violon note that plays at different speed than the others. The AIs are on a platform from which they can fall. If they fall, they disappear, and the sound does too.

Prototype 2: Audio guide --> This prototype appears as an audio guide to explore the world of Tanks!. Each element from the game is replaced by a white prism and when the tank (in a FPS format) collide with the object, Daisy, the audio guide, gives the player a description of the object.


## Feb 10th, 2018: First thoughts on Sound

**Ideas**

*SOUND*
- commentator of the game: commentator(s) describe everything around you without you knowing what it is. → a bit boring, probably already made, not much to learn about video game making, but potentially funny
- alvin lucier "I am sitting in a room" : how and what to record? there is no real space in video game, lucier what studying the resonance/acoustic of the room he was sitting into. But if the room is virtual, is there such thing as acoustic, except the one that can be created artificially by the maker?
- modular synth: cool stuff.
- machine learning, like little Albert experiment: teaching fear to a tank through sounds.
- multiple sound sources that make sense only when you positioned yourself perfectly in the middle between the sources.
- sick AI, sneezing AI, atchooo.. addition of common sounds until very loud and messy, filling the cage
- dance to music otherwise your tank will die. dance to the death!! The beat is accelerating! Tank tank revolution: very good training.
- sound journey: not really original.
- creating a bunch of rooms with different acoustic qualities and the "proutprout" + background music are modified according to that. Again, is there something as acoustic in game?
- AI creating music. additive synth using AI? or substrative synth.
- synaesthesia..
- stereo inversion: inverting the panning of the sound
- music when shooting for a note
- dancing tanks, partyyyyy! you attend a tank pary.
- tank as the instrument, the system, the wheels look just like a recorder!!!!
- sound inside the tank head, “Ommmmmmmm...”
- every time you hit something it tells you what it is. audio guide style: might be funny. the voice would be an online free voice such as text to speech
- experimenting moving the audio listener in weird place: humm the result is not as convincing as I imagined. But I think that the idea is worth pushing forward.

## Feb 5th, 2018: Final built

The final built has been completed. I decided to include a title before each chapter. And to make WASD the only controls along the game. The audio is not destroyed with every new scene which gives a sense of continuity in this "spiritual" quest.

Also I feel confident about my choice of locating "the mother" prototype in the middle of the game since it is the only one that doesn't require player input to move forward. Now that it is built, it appears as a nostalgic interlude revealing the origin of the tanks through the vision of their childhood.

![alt text](https://github.com/sambourgault/cart415/blob/master/tanks_cam.png)

## Feb 1st, 2018: Attending background music

I selected a sample of the original Tanks! music soundtrack and processed it through Ableton Live and with some audio effects available on Unity (reverb and LPF). We still hear a bit of the previous melody but it is a lot more airy due to the delays.

Here is the order of the games.
1. The infinite
2. The void
3. The mother
4. The traffic
5. The god

I want to begin with this cool hack of the infinite zoom to set the table to what is coming next. This series of games will let the player discover the spiritual life of a tanks, starting off with its inner side. Then the player steps into the tanks everyday life, where exists only sex and loneliness. In a play of perspective, the middle chapter reveals the origin of every tanks, its mother. Following, another glimpse at inner world of tanks, this time, stuck in traffic. And finally the series ends with the player being both, the camera and God. They are now God, therefore they can stop playing whenever they want.

I'm still hesitating in showing up the title of each little game. It might be too obvious what the game is about then or very confusing without the titles.

## Jan 31th, 2018: Touch up before adding sound and gathering them

Prototype 1: High highway --> I removed the second highway to simplify the visual.

Prototype 4: Infinite zoom --> As you zoom in, the inner tank is surrounded by more and more cacti.

Prototype 5: Enter the void --> In this world of tanks, tanks are either alone in their house turning around in circle or having sex. This is a pretty binary world but tanks know nothing else.

Prototype 6: Mother --> No significant change.

Prototype 7: God --> I increased the amount of tanks, so that God gets more followers.

Now I must add an ambient sound to replace the horrible music that is starting to get me crazy, I might reuse it but distort it a lot. I also need some sounds for specific moments: when the tanks turn toward their god, for the vibrating tank, and for the baby tanks drinking milk from their mother tank.

## Jan 30th, 2018: New versions

Other ideas came up while I was biking the other day. Moving my legs in circle activates my brain in a strange but recurrent way.

Prototype 6: You are the camera attached to the eyes of each tank in the scene (8). You jump from one perspective to the other but you remain confused by what you see since the framing doesn't tell much about your surrounding. When you finally look at the scene from the main camera's perspective, you realized that you are attending a scene where tank babies are drinking their tank mother milk. The camera's perspective becomes the only way to fully understand what is going on.

Prototype 7: You are the camera and you look at dozens of tanks. The tanks keep facing you because you are their god, their leader, and they need you. In this prototype de camera becomes the main points of attention. The passive and active roles are inverted.

*A question remains, how to connect the prototypes together in a comprehensive/coherent way??*
One option is to present the game as a series of spiritual quests for the tanks.

## Jan 22th, 2018: Still brainstroming for ideas

I ended up pushing further Prototype 1 (Traffic) and Prototype 4 (Volte-Face).

Prototype 1: You are a camera located on a tanks highway but you are stuck in traffic. Your ability to pierce the most solid carcass with your sight lets you see inside the tanks that are moving slowly towards an end. This prototype strives to discover the humanity within the metal frame of the destroying machine. It could be pushed further by adding conversation between the pilots of the tanks.

Prototype 2: You play a casual shooting game, but when you die your tank soul leaves your tank body and starts moving around.

Prototype 3: You are a tank and you try to find tank buddies to play with you, but every tank is busy.

Prototype 4: You are the camera and you zoom inside the tank’s barrel. You discover the inner side of the tank, with all its vulnerability. There is a close relationship between the camera and the gun since they have shared similar features in their early developments. This affiliation explains the use of the expression “shooting” to describe the operation of both tools. So what happens if the camera is shooting the tank’s turret? Is it history revolving? This prototype is an infinite zoom through the tank past, present and future.

Prototype 5: You are a camera and you move through walls in order to see the tank intimacy, what are they doing when human are not playing the TANKS! game?

## Jan 21th, 2018: Ideas for first prototypes

**Ideas**

*CAMERA*
- photo montage like La Jetee.
- small variations between cuts, in the position of objects
- no background erasing
- people inside the tanks and camera inside
- camera filming the front of the tanks
- low angle shot from the trunk of the tanks
- play with zoom in or zooming out
- camera rotates along z-axis and gravity changes with it. (inception style)
- going from one room to the other with the camera (enter the void).. maybe the players is just entering the intimacy of the tanks, where they live, in their apartments, while getting a shower, etc.. and the camera is always moving horizontally and vertically.
- limitless zoom, or zooming out (from pixel to infinity) (limitless)
- vertigo effect (vertigo)
- transparencies, layers on top of each other

*LIGHT*
- shadows moving if light moves in branches for example
- silhouette of the tanks from afar
- stage lighting
- black and white

*OTHER*
- answering questions
- simplification of the game (cube for tank)
- long corridors in space
- tank is alone in the world, in a world but there are highways full of tanks going in one direction that don’t want to play with you. traffic of tanks.
- instructions to the tanks
- dancing tanks


## Jan 12th, 2018: First intervention

I just submit a first intervention for TANKS!, in which instead of shooting at each other, the tanks are thanking each other. Starting with a casual "thank you!", they start arguing about who is thanking whom. In the end, the tanks are fighting again, with words this time.

It reminds me of Jean-Paul Sartre's scenario "L'Engrenage" or Albert Camus's play "Les Justes", which both discuss an authoritarian political climate that revolutionaries try to change by force. But once in power, they end up reproducing the same patterns that they were fighting against not long ago.

I developed it quickly thinking, first, that I would replace the shells, because i have no interest in war/shooting games and, second, that the pun on "tanks" and "thanks" was funny enough to exploit.


## Jan 9th, 2018 : First thoughts on TANKS!

- the yellow color of the desert is now flooding my screen. everything is working except the dust trails that resemble more to a grandpa coughing than anything else.
- i suck at driving a tank. i can figure out why i never got my license.
- i am a videogame looser. i prefer wandering around.

**On TANKS!**

*General comments on current state*
- the map feels too big for me, i wish it was more intimate. it feels dry, not because of the desert context.
- the only light is a directional light acting as a sun.
- the camera is orthographic and it changes size and zoom according to the tanks relative position.
- why do tanks want to kill each other?
- why can you get more than one life?

*General comments on future states*

What if..
- the map consisted in little platforms separated from each other. movements would be irrelevant.
- the lights were stroboscopic like in a night club.
- the tanks would exchange words instead of shell (sooo diplomatic).
- the tanks would film each other in a voyeuristic way.
- the tanks would shoot seeds and create a garden.
- the tanks would get their period once a month, and that would suck so much.
- the game was called THANKS!.
- their would be plenty of false tanks (false as simulation), so you would win if you kill the right one.
- maybe there won't be a right one.
