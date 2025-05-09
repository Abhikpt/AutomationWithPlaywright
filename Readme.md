
## seting-up Multiple Project

1.  create a folder AutomationWithPlayWright


2. created Readme.md for tracking notes 

3.  created an solution file AutomationWithPlaywright.sln 
```bash
	dotnet new sln
```


4. Create the  FrameWorkDesign project

- In solution directory add Class library projects by using below cmd
```bash
	dotnet new classlib -n FrameWorkDesign
```
- Write the supported classes
- Add it's reference in solution
- Add reference of Frameworkdesign project into FlipkartApp. by going to root project directory of FlipkartApp and run below cmd
```bash
dotnet add reference ../FrameWorkDesign\FrameWorkDesign.csproj
```


5. Create Specflow Project FlipkartApp

- In solution directoy run below cmd to create project
```bash
	dotnet new specflowproject -o FlipkartApp
```
- run the below command if need to upgrade all frameworks [Optional]:
```bash
	dotnet tool install -g upgrade-assistant
	upgrade-assistant upgrade
```
- Install the Playwright NuGet package:
```bash
	 dotnet add package Microsoft.Playwright
```

- Add these project reference in solutions
```bash
dotnet sln AutomationWithPlaywright.sln add FlipkartApp\FlipkartApp.csproj
```


6. Create the PracticeAPP project 

- In solution directoy run below cmd to create project
```bash 
 dotnet new nunit -o PracticeApp
```
- Install the Playwright NuGet package:
```bash
	 dotnet add package Microsoft.Playwright
```
- Add the reference of project in solution to make test visisble in explorer
```bash
dotnet sln AutomationWithPlaywright.sln add PracticeApp\PracticeApp.csproj
```


7. Build the code
```bash
	dotnet build
```

8. Run the test from test runner or cmd
```bash
	dotnet test
```


### Notes:
- If executable path not provided then need to run beloe cmd so that excutable exist
```bash
pwsh bin/Debug/netX/playwright.ps1 install  
```


 