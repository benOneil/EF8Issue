Attempt to show EFcore issues #32771 & #32779, Compiled Models Generates 'char' instead of 'varchar'.

Use DBScript.txt to generate test database with data in SQLServer
Open the Visual Studio solution and edit the SQL connection string 
Run Project and record the output.

The query outputs the following: 

Jo
Joe
John
Johnny
Johnson

Uncomment the line optionsBuilder.UseModel in CompiledModelsIssueContext,
Run Project and record the output.

The query outputs the following:

Jo
Joe


