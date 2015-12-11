Welcome to Clipformy!
-----------------------

A simple tool that allows to apply the power of transformy.io in any app by using the Windows clipboard.

The basic idea, and simplest use case, is that you copy some text to the clipboard, somehow execute Clipformy and the text on the clipboard will get transformed, ready to be pasted!

Clipformy can also be used alone ;)

#### Download & Installation

For now the only way is to clone the repo and compile it, sorry :(  
You'll need Visual Studio 2012.

We could add a compiled version if we see fit.

#### Usage

There are mainly three ways of using Clipformy:

1. **Run & use:** just run Clipformy, fill in the textboxes and press "Transform", you will get the results in the "Results" texbox.

2. **Copy, run & use:** copy some text to the clipboard and run Clipformy, you will get the text from the clipboard already filled into the "Source" textbox. Then just proceed as in case one ;)

3. **Copy with format, run & paste:** copy text with a simple special format to the clipboard and run Clipformy. All the required info will be automatically inferred, transformed and copied to the clipboard, you will hear a beep afterwards indicating that the conversion was succesful and the program will close.  
The currently expected format is:
	- 1 line of text (target)
	- 2 blank lines (can contain tabs or spaces)
	- 1 or more lines of text (source)
	
    Ie:

    ```
        Lucas is 32 years old!


        Lucas 32
        Mauro 31
        Clara 29 
    ```

**Our preferred way:**

- Create a shortcut to the exe file.
- Edit the shortcut and add a keyboard shortcut to it.
- In any program, just copy the formatted text, press the keyboard shortcut, wait for the beep and paste (*)!
- Don't worry you messed up with the text formatting, if the data couldn't be inferred the window will remain open ;)

(\*) *Unluckily when you press the shortcut, the window you were working on loses focus and it doesn't get it back once the transformation is done, you will have to go back to the window manually in order to paste the result. We are thinking ways of improving this ;)* 

### Bugs, contact & contributions

Just file an issue on GitHub or send a PR!!

### License

Read `LICENSE` 

We are in no way affiliated with transformy.io, except for the fact that we use their awesome API. Kudos to them!

