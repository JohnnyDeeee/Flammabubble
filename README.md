TODO
- [x] Implement inserting records into Database
- [x] Implement retrieving records from Database
- [x] Implement Interface builder
- [x] Create custom interface using the Interface builder
- [x] Implement some sort of function that can set a input's value depending on other input values realtime
- [x] Fix problem where the ID's of different interfaces are the same
	- Thought i could use the AutoId of LiteDB, but doesn't seem to work (check https://github.com/mbdavid/LiteDB/issues/796)
- [x] Be able to delete records
- [x] Interfaces dissappear when refreshing an interface
- [ ] Be able to edit records

# How does it work
There are 2 modes this program provides: Insert mode, Retrieve mode.

## Insert mode
This is the first and default mode the program starts up in.
In this mode you can see all the Interfaces that are created.

### Interface
An Interface is a collection of input fields.
Each interface can have it's own Record and Collection.

#### Record
A Record is a group of 'properties' which are save together in the Database inside a Collection.

#### Collection
A Collection is a group of Records inside the Database.

## Retrieve mode
**(note to self) TODO: Show the collection names for each record in the retrieve mode**

In this (basic) mode, you can see all the records that are inside the Database.
You can click on a List item to view all the Record's properties and their values.

# How do i add interfaces?
To add an Interface you must create an Interface class.
I have created a template file you can copy+paste and rename (F2).
I suggest naming it something along the lines of "InterfaceXXXX".
Once you have done that you need to open the file and rename the class name 
```c#
public class InterfaceTemplate : Interface {
```
to
```c#
public class InterfaceXXXX : Interface {
```
and the constructor name
```c#
public InterfaceTemplate(Panel parentControl) : base(parentControl) {
```
to
```c#
public InterfaceXXXX(Panel parentControl) : base(parentControl) {
```
and the Record class name
```c#
public class RecordTemplate : Record { }
```
to something along the lines of "RecordXXXX"
```c#
public class RecordXXXX : Record { }
```
or if you dont need to save anything from this interface to the Database you can remove this line completely.
Now you have your own interface but it is not going to be rendered yet.
To do this you need to go in `InterfacesToRender.cs` and add a new line below the comment.
```c#
interfaces.Add(new InterfaceXXXX(parentControl));
```
Now if you start the program (F5, or click the green arrow icon), you will see that you interface is rendered.
Well kind of...
It's empty, because we haven't added any Rows into it.

## Rows
To keep this simple for you i have created a 'limited' editor.
This program is created in Winforms (Windows Forms Application: https://en.wikipedia.org/wiki/Windows_Forms) and it has a pretty big editor to create simple looking GUIs.
But i do not have the time to explain the whole editor and i don't think you will like that either.
So i created this concept of Interfaces and an Interface can have multiple Rows.
A Row is basically a label with an input field.
To create a Row you can use the following method inside your Interface's `CreateInterface()` method.
```c#
new Row(label, inputType, items, value, onClick, onChange)
```
This will create a new Row object with the given values and return it.
So if you want to make for example an input for "total gold", the code will look like this.
```c#
Row inputTotalGold = new Row("Total Gold:", InputType.Input);
```
Let's inspect this piece of code.
```c#
Row inputTotalGold = ...
```
This basically means, store the Row object inside a variable so we can reference it later.
It will become clear later on why we need this.
```c#
new Row("Total Gold:", ...)
```
Give the label of this row the text "Total Gold:".
```c#
new Row(... InputType.Input)
```
This tells the system what kind of input to render.
The choices are currently limited to
- Text = A simple text field
- Dropdown = A dropdown list with multiple items
- ReadOnly = A text field which cannot be edited
- Button = A button with text on it

You can supply more values to this function to extend this input.
**I highly recommend reading through the `InterfaceBasic.cs` file, because this is a custom Interface i created that showcases all the different input types.**

Now to render this `inputTotalGold` we need to add it to the InterfaceBuilder's 'rows' list.
```c#
base.interfaceBuilder.AddRow(inputTotalGold);
```
This adds the input to the list and it is ready to be rendered.
To start the rendering, call this function.
```c#
base.interfaceBuilder.Build(this.collectionName);
```
This will render all the Rows in the 'rows' list to screen.
The parameter that i pass to Build(), is the title of the 'group box' on the screen.
I use `this.collectionName` but you can use whatever name you like, for example.
```c#
base.interfaceBuilder.Build("Super cool new Interface i created");
```
Now we are ready to start the program again (F5, or click the green arrow icon).
Yaay! Our Interface has an input inside it :)
From here on you can add more Rows to your interface and create more Interfaces if you like.

But wait! How do we save my input to the Database?

## Saving interface data
If we want to save data we first need to tell the system how this data is going to look.
What is the data 'structure', this is defined by creating a class that inherits the Record class.
```c#
public class RecordXXXX : Record { }
```
In this Record class we should define some 'properties'.
Let's say we want to save the input of `inputTotalGold`.
```c#
public class RecordXXXX : Record {
	public int totalGold { get; set; }
}
```
Let's inspect this piece of code.
```c#
public int ...
```
Basically means, this type of value is an Integer (number).
Other types are `string`, `object`, etc (more info: https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types-and-variables).
```c#
... totalGold { get; set; }
```
The first part is the name of the property, after that is a short way of generating getters and setters for this property (more info: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties).
The name of the property is the name that is going to show up when inspecting a Record in the Retrieve mode.

Now that we have a Record we can start putting values in it.
We need to create an object reference to the Record so we can use it.
Add this below the Interface class definition.
```c#
public RecordXXXX record = new RecordXXXX();
```
This creates a new Record with default values (default value for `int` is `0`).
Now to 'capute' the value of our `inputTotalGold` we need to use the `onChange` parameter of the `new Row()` function (it is actually a constructor, more info: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors).
In the `onChange` parameter we can supply a function (or Action, more info: https://docs.microsoft.com/en-us/dotnet/api/system.action-1?view=netframework-4.7.2).
that is called everythime the value of a input changes.
Let's add a piece of code to the `onChange` that will auto-update the `record.totalGold` property.
```c#
Row inputTotalGold = new Row("Total Gold:", InputType.Input, onChange: (newValue) => { this.record.totalGold = base.StringToInt(newValue.ToString()); });
```
Let's inspect.
```c#
new Row(... onChange: ...);
```
This is a handy feature that allows us to skip optional parameters.
The whole parameter list for this constructor is bigger than just `(label, inputType, onChange)`.
as we've seen. But things like the parameter `items` are not needed for a simple text input, so we dont want to type out `("Total Gold:", inputType.Text, null, (newValue) => { ... })`.
Instead we can say explicitly what parameter we are filling in.
```c#
new Row(... (newValue) => { ... });
```
This notation `(x) => { }` is called a Lambda (more info: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions).
In short: it's a short anonymous function.
This function will get called everytime the value of the input changes and it will give the new value as a parameter to this function.
```c#
new Row(... => { this.record.totalGold = base.StringToInt(newValue.ToString()); });
```
This shouldn't be hard to grasp.
It sets the record's `totalGold` property to the value of the input.
`base.StringToInt()` is a function inside Interface.cs (the base class from which we inherit) that converts a string to an int.
Pretty simple stuff, but i've added it to prevent some erorrs.

Now we have a value in our Record, but we still haven't saved it to the Database.

Let's add a button that does this for us.
```c#
Row inputSave = new Row("",
    InputType.Button,
    value: "Save",
    onClick: this.SaveToDB);
base.interfaceBuilder.AddRow(inputSave);
```
This save button executes a function called "SaveToDB".
But wait.. this function doesn't exist yet.
We need to add this to our class.
```c#
private void SaveToDB() {
    Database.SaveRecord(this.COLLECTION_NAME, this.record);
}
```
In short: This saves our Record (with all its values) to the Database under the collection name we provide.

Now start the application and type a value, hit save, go to the Retrieve Mode and click on your record.
If everything went well you can see your `totalGold` amount.
