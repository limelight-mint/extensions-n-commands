# Bash Snippets

### Move to other directory

> cd ./path/to/directory
> cd /

First is absolute path, second one is relative.
`.` - current directory
`..` - parent directory
`~` - home directory

### Get current path (directory)

> pwd

Shows current path where are u at

### Get path folders and files (either current or not)

> ls /any/path/directory
> ls

Shows list of files.
`ls` - current directory files
`ls <path>` - files in that path
`ls -a` - shows hidden folders and files
`ls -l` - shows additional info about files

### Get current content in file

> cat <file.txt/or/path/to/file>

Shows file content

### Get paginated content in file

> less <file.txt/or/path/to/file>

Shows file content, however only things that are capable to draw in console window. To navigate use `ARROWS on keyboard`, or close the preview with `Q` button.

### Get real file format (even if its not set)

> file <my_cool_text.txt/file_with_no_type>

Shows the real type of a file, for example if you have downloaded file like `not_hidden.txt` and `hidden`, you can use `file hidden` and see the real file format, or even if file is broken manually edited into `hidden.png` but it was actually a GIF or ZIP you can check it by running `file hidden.png`

### Print a string on a console

> echo <anything>

A `hello world` basically, will print whatever u said

### Copy file

> cp <your_file> <copy_to_filepath>

Copies `your_file` to the path of `copy_to_filepath`

### Move file

> mv <your_file> <move_to_filepath>

Moves `your_file` to the path of `move_to_filepath`

### Remove file

> rm <your_file>

Removes your file (single). To remove directory use `rm -r`.
`rm -r` - removes entire directory

### Create directory (folders)

> mkdir <directory>

Creates a directory with path provided into `directory`

### Get strings from a file

> strings <your_file>

Shows all the symbols/strings from a file `your_file`
