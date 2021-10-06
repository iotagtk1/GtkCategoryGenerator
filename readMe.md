********### GtkCategoryGenerator

This tool copies the CS file and automatically generates the partial class. 
Copy the string for the partial class name. 
The copy will become part of the file name when the tool is run.

##### Example
```
test+copyPerstName.cs
```
##### Run from Rider macro can be used

Settings - Tools - External Tools

Register this app with external tools.

Set the path of the program.

GtkCategoryGenerator set Path

Set the arguments.

```
-fileDir $FilePath$
```

The working Path can be empty.

Uncheck the "Synchronize after execution" box.

When you run the GtkCategoryGenerator, a class file based on the template file will be generated in the project folder.

#### Execution

Select the CS file in Rider's Explorer and run the tool from the right-click External Tools menu

#### Modify the templates at

Modify classTemplate.txt and categoryTemplate.txt.

#### If you cannot build

When importing with Rider, please re-set the file properties to Embeded resource.
Or use AddItem to add it again.