using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.DataServiceTemplate.TTGen
{
    public class TemplateManagerGen
    {
        public static string Text { get; set; } =
            "<#@ assembly name=\"System.Core\" #>\r\n" +
            "<#@ assembly name=\"System.Data\" #>\r\n" +
            "<#@ assembly name=\"System.Data.Entity\" #>\r\n" +
            "<#@ assembly name=\"System.Xml\" #>\r\n" +
            "<#@ assembly name=\"System.Xml.Linq\"#>\r\n" +
            "<#@ assembly name=\"System.Windows.Forms\" #>\r\n" +
            "<#@ assembly name=\"EnvDTE\"#>\r\n" +
            "<#@ assembly name=\"EnvDTE80\" #>\r\n" +
            "<#@ assembly name=\"Microsoft.VisualStudio.Shell.10.0\"#>\r\n" +
            "<#@ assembly name=\"Microsoft.VisualStudio.Shell.Interop \"#>\r\n" +
            "<#@ import namespace=\"Microsoft.VisualStudio.Shell.Interop\"#>\r\n" +
            "<#@ import namespace=\"System\" #>\r\n" +
            "<#@ import namespace=\"System.Data\" #>\r\n" +
            "<#@ import namespace=\"System.Data.Objects\" #>\r\n" +
            "<#@ import namespace=\"System.Linq\" #>\r\n" +
            "<#@ import namespace=\"System.IO\" #>\r\n" +
            "<#@ import namespace=\"System.Collections.Generic\" #>\r\n" +
            "<#@ import namespace=\"System.Data.Objects.DataClasses\" #>\r\n" +
            "<#@ import namespace=\"System.Text.RegularExpressions\" #>\r\n" +
            "<#@ import namespace=\"System.Xml\" #>\r\n" +
            "<#@ import namespace=\"System.Xml.Linq\" #>\r\n" +
            "<#@ import namespace=\"System.Globalization\" #>\r\n" +
            "<#@ import namespace=\"System.Reflection\" #>\r\n" +
            "<#@ import namespace=\"System.CodeDom\" #>\r\n" +
            "<#@ import namespace=\"System.CodeDom.Compiler\" #>\r\n" +
            "<#@ import namespace=\"Microsoft.CSharp\"#>\r\n" +
            "<#@ import namespace=\"System.Text\"#>\r\n" +
            "<#@ import namespace=\"EnvDTE\" #>\r\n" +
            "<#@ import namespace=\"Microsoft.VisualStudio.TextTemplating\" #>\r\n" +
            "<#+ \r\n" +
            "/*\r\n" +
            "   This software is supplied \"AS IS\". The authors disclaim all warranties, \r\n" +
            "   expressed or implied, including, without limitation, the warranties of \r\n" +
            "   merchantability and of fitness for any purpose. The authors assume no\r\n" +
            "   liability for direct, indirect, incidental, special, exemplary, or\r\n" +
            "   consequential damages, which may result from the use of this software,\r\n" +
            "   even if advised of the possibility of such damage.\r\n" +
            "\r\n" +
            "The TemplateFileManager is based on EntityFrameworkTemplateFileManager (EFTFM) from MS.\r\n" +
            "\r\n" +
            "Differences to EFTFM\r\n" +
            "Version 2.1:\r\n" +
            "- Replace Enum BuildAction with class for more flexibility\r\n" +
            "Version 2:\r\n" +
            "- StartHeader works with Parameter $filename$\r\n" +
            "- StartNewFile has a new named parameter FileProperties\r\n" +
            "  - Support for:\r\n" +
            "   - BuildAction\r\n" +
            "   - CustomTool\r\n" +
            "   - user defined parameter for using in StartHeader-Block\r\n" +
            "- Property IsAutoIndentEnabled for support Format Document (C#, VB) when set to true\r\n" +
            "\r\n" +
            "Version: 1.1\r\n" +
            "Add method WriteLineToBuildPane, WriteToBuildPane\r\n" +
            "\r\n" +
            "Version 1:\r\n" +
            "- StartNewFile with named parameters projectName and folderName for generating files to different locations.\r\n" +
            "- Property CanOverrideExistingFile, to define whether existing files are can overwritten\r\n" +
            "- Property Encoding Encode type for output files.\r\n" +
            "*/\r\n" +
            "\r\n" +
            "/// <summary>\r\n" +
            "/// Writes a line to the build pane in visual studio and activates it\r\n" +
            "/// </summary>\r\n" +
            "/// <param name=\"message\">Text to output - a is appended</param>\r\n" +
            "void WriteLineToBuildPane (string message){\r\n" +
            "       WriteLineToBuildPane(String.Format(\"{0}\", message));\r\n" +
            "}\r\n" +
            "\r\n" +
            "/// <summary>\r\n" +
            "/// Writes a string to the build pane in visual studio and activates it\r\n" +
            "/// </summary>\r\n" +
            "/// <param name=\"message\">Text to output</param>\r\n" +
            "void WriteToBuildPane (string message){\r\n" +
            "       IVsOutputWindow outWindow = (this.Host as IServiceProvider).GetService(\r\n" +
            "typeof( SVsOutputWindow ) ) as IVsOutputWindow;\r\n" +
            "       Guid generalPaneGuid =\r\n" +
            "Microsoft.VisualStudio.VSConstants.OutputWindowPaneGuid.BuildOutputPane_guid;\r\n" +
            "		// P.S. There's also the GUID_OutWindowDebugPane available.\r\n" +
            "       IVsOutputWindowPane generalPane;\r\n" +
            "       outWindow.GetPane( ref generalPaneGuid , out generalPane );\r\n" +
            "       generalPane.OutputString( message  );\r\n" +
            "       generalPane.Activate(); // Brings this pane into view\r\n" +
            "}\r\n" +
            "\r\n" +
            "/// <summary>\r\n" +
            "/// Responsible for marking the various sections of the generation,\r\n" +
            "/// so they can be split up into separate files and projects\r\n" +
            "/// </summary>\r\n" +
            "/// <author>R. Leupold</author>\r\n" +
            "public class TemplateFileManager\r\n" +
            "{\r\n" +
            "	private EnvDTE.ProjectItem templateProjectItem;\r\n" +
            "    private Action<string> checkOutAction;\r\n" +
            "    private Action<IEnumerable<OutputFile>> projectSyncAction;\r\n" +
            "	private EnvDTE.DTE dte;\r\n" +
            "	private List<string> templatePlaceholderList = new List<string>();\r\n" +
            "	\r\n" +
            "    /// <summary>\r\n" +
            "    /// Creates files with VS sync\r\n" +
            "    /// </summary>\r\n" +
            "    public static TemplateFileManager Create(object textTransformation)\r\n" +
            "    {\r\n" +
            "        DynamicTextTransformation2 transformation = DynamicTextTransformation2.Create(textTransformation);\r\n" +
            "        IDynamicHost2 host = transformation.Host;\r\n" +
            "        return new TemplateFileManager(transformation);\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    private readonly List<Block> files = new List<Block>();\r\n" +
            "    private readonly Block footer = new Block();\r\n" +
            "    private readonly Block header = new Block();\r\n" +
            "    private readonly DynamicTextTransformation2 _textTransformation;\r\n" +
            "\r\n" +
            "    // reference to the GenerationEnvironment StringBuilder on the\r\n" +
            "    // TextTransformation object\r\n" +
            "    private readonly StringBuilder _generationEnvironment;\r\n" +
            "\r\n" +
            "    private Block currentBlock;\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// Initializes an TemplateFileManager Instance  with the\r\n" +
            "    /// TextTransformation (T4 generated class) that is currently running\r\n" +
            "    /// </summary>\r\n" +
            "    private TemplateFileManager(object textTransformation)\r\n" +
            "    {\r\n" +
            "        if (textTransformation == null)\r\n" +
            "        {\r\n" +
            "            throw new ArgumentNullException(\"textTransformation\");\r\n" +
            "        }\r\n" +
            "				\r\n" +
            "        _textTransformation = DynamicTextTransformation2.Create(textTransformation);\r\n" +
            "        _generationEnvironment = _textTransformation.GenerationEnvironment;\r\n" +
            "		\r\n" +
            "		var hostServiceProvider = _textTransformation.Host.AsIServiceProvider();\r\n" +
            "        if (hostServiceProvider == null)\r\n" +
            "        {\r\n" +
            "            throw new ArgumentNullException(\"Could not obtain hostServiceProvider\");\r\n" +
            "        }\r\n" +
            "\r\n" +
            "        dte = (EnvDTE.DTE) hostServiceProvider.GetService(typeof(EnvDTE.DTE));\r\n" +
            "        if (dte == null)\r\n" +
            "        {\r\n" +
            "            throw new ArgumentNullException(\"Could not obtain DTE from host\");\r\n" +
            "        }\r\n" +
            "		\r\n" +
            "		this.templateProjectItem = dte.Solution.FindProjectItem(_textTransformation.Host.TemplateFile);\r\n" +
            "		this.CanOverrideExistingFile = true;\r\n" +
            "		this.IsAutoIndentEnabled = false;\r\n" +
            "		this.Encoding = System.Text.Encoding.UTF8;\r\n" +
            "        checkOutAction = fileName => dte.SourceControl.CheckOutItem(fileName);\r\n" +
            "        projectSyncAction = keepFileNames => ProjectSync(templateProjectItem, keepFileNames);\r\n" +
            "    }\r\n" +
            "\r\n" +
            "	/// <summary>\r\n" +
            "	/// If set to false, existing files are not overwritten\r\n" +
            "	/// </summary>\r\n" +
            "	/// <returns></returns>\r\n" +
            "	public bool CanOverrideExistingFile { get; set; }\r\n" +
            "	\r\n" +
            "	/// <summary>\r\n" +
            "	/// If set to true, output files (c#, vb) are formatted based on the vs settings.\r\n" +
            "	/// </summary>\r\n" +
            "	/// <returns></returns>\r\n" +
            "	public bool IsAutoIndentEnabled { get; set; }\r\n" +
            "	\r\n" +
            "	/// <summary>\r\n" +
            "	/// Defines Encoding format for generated output file. (Default UTF8)\r\n" +
            "	/// </summary>\r\n" +
            "	/// <returns></returns>\r\n" +
            "	public System.Text.Encoding Encoding { get; set; }\r\n" +
            "	\r\n" +
            "    /// <summary>\r\n" +
            "    /// Marks the end of the last file if there was one, and starts a new\r\n" +
            "    /// and marks this point in generation as a new file.\r\n" +
            "    /// </summary>\r\n" +
            "	/// <param name=\"name\">Filename</param>\r\n" +
            "	/// <param name=\"projectName\">Name of the target project for the new file.</param>\r\n" +
            "	/// <param name=\"folderName\">Name of the target folder for the new file.</param>\r\n" +
            "	/// <param name=\"fileProperties\">File property settings in vs for the new File</param>\r\n" +
            "    public void StartNewFile(string name\r\n" +
            "		, string projectName = \"\", string folderName = \"\", FileProperties fileProperties = null)\r\n" +
            "    {\r\n" +
            "        if (String.IsNullOrWhiteSpace(name) == true)\r\n" +
            "        {\r\n" +
            "            throw new ArgumentException(\"name\");\r\n" +
            "        }\r\n" +
            "\r\n" +
            "        CurrentBlock = new Block \r\n" +
            "					  { \r\n" +
            "						Name = name, \r\n" +
            "						ProjectName = projectName, \r\n" +
            "						FolderName = folderName,\r\n" +
            "						FileProperties = fileProperties ?? new FileProperties()\r\n" +
            "					  };\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    public void StartFooter()\r\n" +
            "    {\r\n" +
            "        CurrentBlock = footer;\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    public void StartHeader()\r\n" +
            "    {\r\n" +
            "        CurrentBlock = header;\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    public void EndBlock()\r\n" +
            "    {\r\n" +
            "        if (CurrentBlock == null)\r\n" +
            "        {\r\n" +
            "            return;\r\n" +
            "        }\r\n" +
            "\r\n" +
            "        CurrentBlock.Length = _generationEnvironment.Length - CurrentBlock.Start;\r\n" +
            "\r\n" +
            "        if (CurrentBlock != header && CurrentBlock != footer)\r\n" +
            "        {\r\n" +
            "            files.Add(CurrentBlock);\r\n" +
            "        }\r\n" +
            "\r\n" +
            "        currentBlock = null;\r\n" +
            "    }\r\n" +
            "	\r\n" +
            "    /// <summary>\r\n" +
            "    /// Produce the template output files.\r\n" +
            "    /// </summary>\r\n" +
            "    public virtual IEnumerable<OutputFile> Process(bool split = true)\r\n" +
            "    {\r\n" +
            "		var list = new List<OutputFile>();\r\n" +
            "		\r\n" +
            "        if (split)\r\n" +
            "        {\r\n" +
            "            EndBlock();\r\n" +
            "\r\n" +
            "            var headerText = _generationEnvironment.ToString(header.Start, header.Length);\r\n" +
            "            var footerText = _generationEnvironment.ToString(footer.Start, footer.Length);\r\n" +
            "            files.Reverse();\r\n" +
            "\r\n" +
            "            foreach (var block in files)\r\n" +
            "            {\r\n" +
            "				var outputPath = VSHelper.GetOutputPath(dte, block, Path.GetDirectoryName(_textTransformation.Host.TemplateFile));\r\n" +
            "                var fileName = Path.Combine(outputPath, block.Name);\r\n" +
            "                var content = this.ReplaceParameter(headerText, block) + \r\n" +
            "				_generationEnvironment.ToString(block.Start, block.Length) + \r\n" +
            "				footerText;\r\n" +
            "\r\n" +
            "                var file = new OutputFile \r\n" +
            "				   { \r\n" +
            "						FileName = fileName, \r\n" +
            "						ProjectName = block.ProjectName, \r\n" +
            "						FolderName = block.FolderName,\r\n" +
            "						FileProperties = block.FileProperties,\r\n" +
            "						Content = content\r\n" +
            "					};\r\n" +
            "				\r\n" +
            "                CreateFile(file);\r\n" +
            "                _generationEnvironment.Remove(block.Start, block.Length);\r\n" +
            "								\r\n" +
            "				list.Add(file);		\r\n" +
            "            }\r\n" +
            "        }\r\n" +
            "		\r\n" +
            "		projectSyncAction.EndInvoke(projectSyncAction.BeginInvoke(list, null, null));\r\n" +
            "		this.CleanUpTemplatePlaceholders();\r\n" +
            "		var items = VSHelper.GetOutputFilesAsProjectItems(this.dte, list);\r\n" +
            "		this.WriteVsProperties(items, list);\r\n" +
            "		\r\n" +
            "		if (this.IsAutoIndentEnabled == true && split == true)\r\n" +
            "		{\r\n" +
            "			this.FormatProjectItems(items);\r\n" +
            "		}\r\n" +
            "			\r\n" +
            "		this.WriteLog(list);\r\n" +
            "		\r\n" +
            "		return list;\r\n" +
            "    }\r\n" +
            "	\r\n" +
            "	private void FormatProjectItems(IEnumerable<EnvDTE.ProjectItem> items)\r\n" +
            "	{\r\n" +
            "		foreach (var item in items)\r\n" +
            "		{\r\n" +
            "			this._textTransformation.WriteLine(\r\n" +
            "			VSHelper.ExecuteVsCommand(this.dte, item, \"Edit.FormatDocument\")); //, \"Edit.RemoveAndSort\"));\r\n" +
            "			this._textTransformation.WriteLine(\"//-> \" + item.Name);\r\n" +
            "		}\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	private void WriteVsProperties(IEnumerable<EnvDTE.ProjectItem> items, IEnumerable<OutputFile> outputFiles)\r\n" +
            "	{\r\n" +
            "		foreach (var file in outputFiles)\r\n" +
            "		{\r\n" +
            "			var item = items.Where(p => p.Name == Path.GetFileName(file.FileName)).FirstOrDefault();\r\n" +
            "			if (item == null) continue; \r\n" +
            "			\r\n" +
            "			if (String.IsNullOrEmpty(file.FileProperties.CustomTool) == false)\r\n" +
            "			{\r\n" +
            "				VSHelper.SetPropertyValue(item, \"CustomTool\", file.FileProperties.CustomTool);\r\n" +
            "			}\r\n" +
            "\r\n" +
            "			if (String.IsNullOrEmpty(file.FileProperties.BuildActionString) == false)\r\n" +
            "			{\r\n" +
            "				VSHelper.SetPropertyValue(item, \"ItemType\", file.FileProperties.BuildActionString);\r\n" +
            "			}\r\n" +
            "		}\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	private string ReplaceParameter(string text, Block block)\r\n" +
            "	{\r\n" +
            "		if (String.IsNullOrEmpty(text) == false)\r\n" +
            "		{\r\n" +
            "			text = text.Replace(\"$filename$\", block.Name);\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		\r\n" +
            "		foreach (var item in block.FileProperties.TemplateParameter.AsEnumerable())\r\n" +
            "		{\r\n" +
            "			text = text.Replace(item.Key, item.Value);\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		return text;\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	/// <summary>\r\n" +
            "	/// Write log to the default output file.\r\n" +
            "	/// </summary>\r\n" +
            "	/// <param name=\"list\"></param>\r\n" +
            "	private void WriteLog(IEnumerable<OutputFile> list)\r\n" +
            "	{\r\n" +
            "		this._textTransformation.WriteLine(\"// Generated helper templates\");\r\n" +
            "		foreach (var item in templatePlaceholderList)\r\n" +
            "		{\r\n" +
            "			this._textTransformation.WriteLine(\"// \" + this.GetDirectorySolutionRelative(item));		 \r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		this._textTransformation.WriteLine(\"// Generated items\");\r\n" +
            "		foreach (var item in list)\r\n" +
            "		{\r\n" +
            "			this._textTransformation.WriteLine(\"// \" + this.GetDirectorySolutionRelative(item.FileName)); \r\n" +
            "		}\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	/// <summary>\r\n" +
            "	/// Removes old template placeholders from the solution.\r\n" +
            "	/// </summary>\r\n" +
            "	private void CleanUpTemplatePlaceholders()		\r\n" +
            "	{\r\n" +
            "		string[] activeTemplateFullNames = this.templatePlaceholderList.ToArray();\r\n" +
            "		string[] allHelperTemplateFullNames = VSHelper.GetAllSolutionItems(this.dte)\r\n" +
            "			.Where(p => p.Name == VSHelper.GetTemplatePlaceholderName(this.templateProjectItem))\r\n" +
            "			.Select(p => VSHelper.GetProjectItemFullPath(p))\r\n" +
            "			.ToArray();\r\n" +
            "		\r\n" +
            "		var delta = allHelperTemplateFullNames.Except(activeTemplateFullNames).ToArray();\r\n" +
            "			\r\n" +
            "		var dirtyHelperTemplates = VSHelper.GetAllSolutionItems(this.dte)\r\n" +
            "			.Where(p => delta.Contains(VSHelper.GetProjectItemFullPath(p)));\r\n" +
            "\r\n" +
            "		foreach (ProjectItem item in dirtyHelperTemplates)\r\n" +
            "		{\r\n" +
            "			if (item.ProjectItems != null)\r\n" +
            "			{\r\n" +
            "				foreach (ProjectItem subItem in item.ProjectItems)\r\n" +
            "				{\r\n" +
            "					subItem.Remove(); \r\n" +
            "				}\r\n" +
            "			}\r\n" +
            "			\r\n" +
            "			item.Remove();\r\n" +
            "		}\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	/// <summary>\r\n" +
            "	/// Gets a list of helper templates from the log.\r\n" +
            "	/// </summary>\r\n" +
            "	/// <returns>List of generated helper templates.</returns>\r\n" +
            "	private string[] GetPreviousTemplatePlaceholdersFromLog()\r\n" +
            "	{\r\n" +
            "		string path = Path.GetDirectoryName(this._textTransformation.Host.ResolvePath(this._textTransformation.Host.TemplateFile));\r\n" +
            "		string file1 = Path.GetFileNameWithoutExtension(this._textTransformation.Host.TemplateFile) + \".txt\";\r\n" +
            "		string contentPrevious = File.ReadAllText(Path.Combine(path, file1));\r\n" +
            "		\r\n" +
            "		var result = contentPrevious\r\n" +
            "              .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)\r\n" +
            "              .Select(x => x.Split(new[] { \"=>\" }, StringSplitOptions.RemoveEmptyEntries).First())\r\n" +
            "              .Select(x => Regex.Replace(x, \"//\", String.Empty).Trim())\r\n" +
            "			  .Where(x => x.EndsWith(VSHelper.GetTemplatePlaceholderName(this.templateProjectItem)))\r\n" +
            "			  .ToArray();\r\n" +
            "		\r\n" +
            "		return result;\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	private string GetDirectorySolutionRelative(string fullName)\r\n" +
            "	{\r\n" +
            "		int slnPos = fullName.IndexOf(Path.GetFileNameWithoutExtension(this.dte.Solution.FileName));\r\n" +
            "		if (slnPos < 0)\r\n" +
            "		{\r\n" +
            "			slnPos = 0;\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		return fullName.Substring(slnPos);\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "    protected virtual void CreateFile(OutputFile file)\r\n" +
            "    {\r\n" +
            "		if (this.CanOverrideExistingFile == false && File.Exists(file.FileName) == true)\r\n" +
            "		{\r\n" +
            "			return;\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "        if (IsFileContentDifferent(file))\r\n" +
            "        {\r\n" +
            "			CheckoutFileIfRequired(file.FileName);\r\n" +
            "            File.WriteAllText(file.FileName, file.Content, this.Encoding);\r\n" +
            "        }\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    protected bool IsFileContentDifferent(OutputFile file)\r\n" +
            "    {\r\n" +
            "        return !(File.Exists(file.FileName) && File.ReadAllText(file.FileName) == file.Content);\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    private Block CurrentBlock\r\n" +
            "    {\r\n" +
            "        get { return currentBlock; }\r\n" +
            "        set\r\n" +
            "        {\r\n" +
            "            if (CurrentBlock != null)\r\n" +
            "            {\r\n" +
            "                EndBlock();\r\n" +
            "            }\r\n" +
            "\r\n" +
            "            if (value != null)\r\n" +
            "            {\r\n" +
            "                value.Start = _generationEnvironment.Length;\r\n" +
            "            }\r\n" +
            "\r\n" +
            "            currentBlock = value;\r\n" +
            "        }		\r\n" +
            "    }\r\n" +
            "	\r\n" +
            "	private void ProjectSync(EnvDTE.ProjectItem templateProjectItem, IEnumerable<OutputFile> keepFileNames)\r\n" +
            "	{\r\n" +
            "		var groupedFileNames = from f in keepFileNames\r\n" +
            "								group f by new { f.ProjectName, f.FolderName }\r\n" +
            "								into l\r\n" +
            "								select new { \r\n" +
            "									ProjectName = l.Key.ProjectName,\r\n" +
            "									FolderName = l.Key.FolderName,\r\n" +
            "									FirstItem = l.First(),\r\n" +
            "									OutputFiles = l\r\n" +
            "								};\r\n" +
            "		\r\n" +
            "		this.templatePlaceholderList.Clear();\r\n" +
            "								\r\n" +
            "		foreach (var item in groupedFileNames)\r\n" +
            "		{\r\n" +
            "			EnvDTE.ProjectItem pi = VSHelper.GetTemplateProjectItem(templateProjectItem.DTE, item.FirstItem, templateProjectItem);\r\n" +
            "			ProjectSyncPart(pi, item.OutputFiles);\r\n" +
            "			\r\n" +
            "			if (pi.Name.EndsWith(\"txt4\"))\r\n" +
            "				this.templatePlaceholderList.Add(VSHelper.GetProjectItemFullPath(pi));			\r\n" +
            "		}\r\n" +
            "	\r\n" +
            "		// clean up\r\n" +
            "		bool hasDefaultItems = groupedFileNames.Where(f => String.IsNullOrEmpty(f.ProjectName) && String.IsNullOrEmpty(f.FolderName)).Count() > 0;\r\n" +
            "		if (hasDefaultItems == false)\r\n" +
            "		{\r\n" +
            "			ProjectSyncPart(templateProjectItem, new List<OutputFile>());\r\n" +
            "		}\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "    private static void ProjectSyncPart(EnvDTE.ProjectItem templateProjectItem, IEnumerable<OutputFile> keepFileNames)\r\n" +
            "    {\r\n" +
            "        var keepFileNameSet = new HashSet<OutputFile>(keepFileNames);\r\n" +
            "        var projectFiles = new Dictionary<string, EnvDTE.ProjectItem>();\r\n" +
            "        var originalOutput = Path.GetFileNameWithoutExtension(templateProjectItem.FileNames[0]);\r\n" +
            "\r\n" +
            "        foreach (EnvDTE.ProjectItem projectItem in templateProjectItem.ProjectItems)\r\n" +
            "        {\r\n" +
            "            projectFiles.Add(projectItem.FileNames[0], projectItem);\r\n" +
            "        }\r\n" +
            "\r\n" +
            "        // Remove unused items from the project\r\n" +
            "        foreach (var pair in projectFiles)\r\n" +
            "        {\r\n" +
            "			bool isNotFound = keepFileNames.Where(f=>f.FileName == pair.Key).Count() == 0;\r\n" +
            "            if (isNotFound == true\r\n" +
            "                && !(Path.GetFileNameWithoutExtension(pair.Key) + \".\").StartsWith(originalOutput + \".\"))\r\n" +
            "            {\r\n" +
            "                pair.Value.Delete();\r\n" +
            "            }\r\n" +
            "        }\r\n" +
            "\r\n" +
            "        // Add missing files to the project\r\n" +
            "        foreach (var fileName in keepFileNameSet)\r\n" +
            "        {\r\n" +
            "            if (!projectFiles.ContainsKey(fileName.FileName))\r\n" +
            "            {\r\n" +
            "                templateProjectItem.ProjectItems.AddFromFile(fileName.FileName);\r\n" +
            "            }\r\n" +
            "        }\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    private void CheckoutFileIfRequired(string fileName)\r\n" +
            "    {\r\n" +
            "        if (dte.SourceControl == null\r\n" +
            "            || !dte.SourceControl.IsItemUnderSCC(fileName)\r\n" +
            "                || dte.SourceControl.IsItemCheckedOut(fileName))\r\n" +
            "        {\r\n" +
            "            return;\r\n" +
            "        }\r\n" +
            "\r\n" +
            "        // run on worker thread to prevent T4 calling back into VS\r\n" +
            "        checkOutAction.EndInvoke(checkOutAction.BeginInvoke(fileName, null, null));\r\n" +
            "    }		\r\n" +
            "}\r\n" +
            "\r\n" +
            "/// <summary>\r\n" +
            "/// Responsible creating an instance that can be passed\r\n" +
            "/// to helper classes that need to access the TextTransformation\r\n" +
            "/// members.  It accesses member by name and signature rather than\r\n" +
            "/// by type.  This is necessary when the\r\n" +
            "/// template is being used in Preprocessed mode\r\n" +
            "/// and there is no common known type that can be\r\n" +
            "/// passed instead\r\n" +
            "/// </summary>\r\n" +
            "public class DynamicTextTransformation2\r\n" +
            "{\r\n" +
            "    private object _instance;\r\n" +
            "    IDynamicHost2 _dynamicHost;\r\n" +
            "\r\n" +
            "    private readonly MethodInfo _write;\r\n" +
            "    private readonly MethodInfo _writeLine;\r\n" +
            "    private readonly PropertyInfo _generationEnvironment;\r\n" +
            "    private readonly PropertyInfo _errors;\r\n" +
            "    private readonly PropertyInfo _host;\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// Creates an instance of the DynamicTextTransformation class around the passed in\r\n" +
            "    /// TextTransformation shapped instance passed in, or if the passed in instance\r\n" +
            "    /// already is a DynamicTextTransformation, it casts it and sends it back.\r\n" +
            "    /// </summary>\r\n" +
            "    public static DynamicTextTransformation2 Create(object instance)\r\n" +
            "    {\r\n" +
            "        if (instance == null)\r\n" +
            "        {\r\n" +
            "            throw new ArgumentNullException(\"instance\");\r\n" +
            "        }\r\n" +
            "\r\n" +
            "        DynamicTextTransformation2 textTransformation = instance as DynamicTextTransformation2;\r\n" +
            "        if (textTransformation != null)\r\n" +
            "        {\r\n" +
            "            return textTransformation;\r\n" +
            "        }\r\n" +
            "\r\n" +
            "        return new DynamicTextTransformation2(instance);\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    private DynamicTextTransformation2(object instance)\r\n" +
            "    {\r\n" +
            "        _instance = instance;\r\n" +
            "        Type type = _instance.GetType();\r\n" +
            "        _write = type.GetMethod(\"Write\", new Type[] { typeof(string) });\r\n" +
            "        _writeLine = type.GetMethod(\"WriteLine\", new Type[] { typeof(string) });\r\n" +
            "        _generationEnvironment = type.GetProperty(\"GenerationEnvironment\", BindingFlags.Instance | BindingFlags.NonPublic);\r\n" +
            "        _host = type.GetProperty(\"Host\");\r\n" +
            "        _errors = type.GetProperty(\"Errors\");\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// Gets the value of the wrapped TextTranformation instance's GenerationEnvironment property\r\n" +
            "    /// </summary>\r\n" +
            "    public StringBuilder GenerationEnvironment { get { return (StringBuilder)_generationEnvironment.GetValue(_instance, null); } }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// Gets the value of the wrapped TextTranformation instance's Errors property\r\n" +
            "    /// </summary>\r\n" +
            "    public System.CodeDom.Compiler.CompilerErrorCollection Errors { get { return (System.CodeDom.Compiler.CompilerErrorCollection)_errors.GetValue(_instance, null); } }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// Calls the wrapped TextTranformation instance's Write method.\r\n" +
            "    /// </summary>\r\n" +
            "    public void Write(string text)\r\n" +
            "    {\r\n" +
            "        _write.Invoke(_instance, new object[] { text });\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// Calls the wrapped TextTranformation instance's WriteLine method.\r\n" +
            "    /// </summary>\r\n" +
            "    public void WriteLine(string text)\r\n" +
            "    {\r\n" +
            "        _writeLine.Invoke(_instance, new object[] { text });\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// Gets the value of the wrapped TextTranformation instance's Host property\r\n" +
            "    /// if available (shows up when hostspecific is set to true in the template directive) and returns\r\n" +
            "    /// the appropriate implementation of IDynamicHost\r\n" +
            "    /// </summary>\r\n" +
            "    public IDynamicHost2 Host\r\n" +
            "    {\r\n" +
            "        get\r\n" +
            "        {\r\n" +
            "            if (_dynamicHost == null)\r\n" +
            "            {\r\n" +
            "                if(_host == null)\r\n" +
            "                {\r\n" +
            "                    _dynamicHost = new NullHost2();\r\n" +
            "                }\r\n" +
            "                else\r\n" +
            "                {\r\n" +
            "                    _dynamicHost = new DynamicHost2(_host.GetValue(_instance, null));\r\n" +
            "                }\r\n" +
            "            }\r\n" +
            "            return _dynamicHost;\r\n" +
            "        }\r\n" +
            "    }\r\n" +
            "}\r\n" +
            "\r\n" +
            "/// <summary>\r\n" +
            "/// Reponsible for abstracting the use of Host between times\r\n" +
            "/// when it is available and not\r\n" +
            "/// </summary>\r\n" +
            "public interface IDynamicHost2\r\n" +
            "{\r\n" +
            "    /// <summary>\r\n" +
            "    /// An abstracted call to Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost ResolveParameterValue\r\n" +
            "    /// </summary>\r\n" +
            "    string ResolveParameterValue(string id, string name, string otherName);\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// An abstracted call to Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost ResolvePath\r\n" +
            "    /// </summary>\r\n" +
            "    string ResolvePath(string path);\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// An abstracted call to Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost TemplateFile\r\n" +
            "    /// </summary>\r\n" +
            "    string TemplateFile { get; }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// Returns the Host instance cast as an IServiceProvider\r\n" +
            "    /// </summary>\r\n" +
            "    IServiceProvider AsIServiceProvider();\r\n" +
            "}\r\n" +
            "\r\n" +
            "/// <summary>\r\n" +
            "/// Reponsible for implementing the IDynamicHost as a dynamic\r\n" +
            "/// shape wrapper over the Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost interface\r\n" +
            "/// rather than type dependent wrapper.  We don't use the\r\n" +
            "/// interface type so that the code can be run in preprocessed mode\r\n" +
            "/// on a .net framework only installed machine.\r\n" +
            "/// </summary>\r\n" +
            "public class DynamicHost2 : IDynamicHost2\r\n" +
            "{\r\n" +
            "    private readonly object _instance;\r\n" +
            "    private readonly MethodInfo _resolveParameterValue;\r\n" +
            "    private readonly MethodInfo _resolvePath;\r\n" +
            "    private readonly PropertyInfo _templateFile;\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// Creates an instance of the DynamicHost class around the passed in\r\n" +
            "    /// Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost shapped instance passed in.\r\n" +
            "    /// </summary>\r\n" +
            "    public DynamicHost2(object instance)\r\n" +
            "    {\r\n" +
            "        _instance = instance;\r\n" +
            "        Type type = _instance.GetType();\r\n" +
            "        _resolveParameterValue = type.GetMethod(\"ResolveParameterValue\", new Type[] { typeof(string), typeof(string), typeof(string) });\r\n" +
            "        _resolvePath = type.GetMethod(\"ResolvePath\", new Type[] { typeof(string) });\r\n" +
            "        _templateFile = type.GetProperty(\"TemplateFile\");\r\n" +
            "\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// A call to Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost ResolveParameterValue\r\n" +
            "    /// </summary>\r\n" +
            "    public string ResolveParameterValue(string id, string name, string otherName)\r\n" +
            "    {\r\n" +
            "        return (string)_resolveParameterValue.Invoke(_instance, new object[] { id, name, otherName });\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// A call to Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost ResolvePath\r\n" +
            "    /// </summary>\r\n" +
            "    public string ResolvePath(string path)\r\n" +
            "    {\r\n" +
            "        return (string)_resolvePath.Invoke(_instance, new object[] { path });\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// A call to Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost TemplateFile\r\n" +
            "    /// </summary>\r\n" +
            "    public string TemplateFile\r\n" +
            "    {\r\n" +
            "        get\r\n" +
            "        {\r\n" +
            "            return (string)_templateFile.GetValue(_instance, null);\r\n" +
            "        }\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// Returns the Host instance cast as an IServiceProvider\r\n" +
            "    /// </summary>\r\n" +
            "    public IServiceProvider AsIServiceProvider()\r\n" +
            "    {\r\n" +
            "        return _instance as IServiceProvider;\r\n" +
            "    }\r\n" +
            "}\r\n" +
            "\r\n" +
            "/// <summary>\r\n" +
            "/// Reponsible for implementing the IDynamicHost when the\r\n" +
            "/// Host property is not available on the TextTemplating type. The Host\r\n" +
            "/// property only exists when the hostspecific attribute of the template\r\n" +
            "/// directive is set to true.\r\n" +
            "/// </summary>\r\n" +
            "public class NullHost2 : IDynamicHost2\r\n" +
            "{\r\n" +
            "    /// <summary>\r\n" +
            "    /// An abstraction of the call to Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost ResolveParameterValue\r\n" +
            "    /// that simply retuns null.\r\n" +
            "    /// </summary>\r\n" +
            "    public string ResolveParameterValue(string id, string name, string otherName)\r\n" +
            "    {\r\n" +
            "        return null;\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// An abstraction of the call to Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost ResolvePath\r\n" +
            "    /// that simply retuns the path passed in.\r\n" +
            "    /// </summary>\r\n" +
            "    public string ResolvePath(string path)\r\n" +
            "    {\r\n" +
            "        return path;\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// An abstraction of the call to Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost TemplateFile\r\n" +
            "    /// that returns null.\r\n" +
            "    /// </summary>\r\n" +
            "    public string TemplateFile\r\n" +
            "    {\r\n" +
            "        get\r\n" +
            "        {\r\n" +
            "            return null;\r\n" +
            "        }\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    /// <summary>\r\n" +
            "    /// Returns null.\r\n" +
            "    /// </summary>\r\n" +
            "    public IServiceProvider AsIServiceProvider()\r\n" +
            "    {\r\n" +
            "        return null;\r\n" +
            "    }\r\n" +
            "}\r\n" +
            "\r\n" +
            "public sealed class Block\r\n" +
            "{\r\n" +
            "    public String Name;\r\n" +
            "    public int Start, Length;\r\n" +
            "	public string ProjectName { get; set; }\r\n" +
            "	public string FolderName { get; set; }\r\n" +
            "	public FileProperties FileProperties { get; set; }\r\n" +
            "}\r\n" +
            "\r\n" +
            "public class ParamTextTemplate\r\n" +
            "{\r\n" +
            "	private ITextTemplatingEngineHost Host { get; set; }\r\n" +
            "	\r\n" +
            "	private ParamTextTemplate(ITextTemplatingEngineHost host)\r\n" +
            "	{\r\n" +
            "		this.Host = host;\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public static ParamTextTemplate Create(ITextTemplatingEngineHost host)\r\n" +
            "	{\r\n" +
            "		return new ParamTextTemplate(host);\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public static TextTemplatingSession GetSessionObject()\r\n" +
            "	{\r\n" +
            "		return new TextTemplatingSession();\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public string TransformText(string templateName, TextTemplatingSession session)\r\n" +
            "	{\r\n" +
            "		return this.GetTemplateContent(templateName, session);\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public string GetTemplateContent(string templateName, TextTemplatingSession session)\r\n" +
            "	{\r\n" +
            "		string fullName = this.Host.ResolvePath(templateName);\r\n" +
            "		string templateContent = File.ReadAllText(fullName);\r\n" +
            "		\r\n" +
            "		var sessionHost = this.Host as ITextTemplatingSessionHost;\r\n" +
            "		sessionHost.Session = session;\r\n" +
            "\r\n" +
            "		Engine engine = new Engine();\r\n" +
            "		return engine.ProcessTemplate(templateContent, this.Host);\r\n" +
            "	}\r\n" +
            "}\r\n" +
            "\r\n" +
            "public class VSHelper\r\n" +
            "{\r\n" +
            "	/// <summary>\r\n" +
            "	/// Execute Visual Studio commands against the project item.\r\n" +
            "	/// </summary>\r\n" +
            "	/// <param name=\"item\">The current project item.</param>\r\n" +
            "	/// <param name=\"command\">The vs command as string.</param>\r\n" +
            "	/// <returns>An error message if the command fails.</returns>\r\n" +
            "	public static string ExecuteVsCommand(EnvDTE.DTE dte, EnvDTE.ProjectItem item, params string[] command)\r\n" +
            "	{\r\n" +
            "		if (item == null)\r\n" +
            "		{\r\n" +
            "			throw new ArgumentNullException(\"item\");\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		string error = String.Empty;\r\n" +
            "		\r\n" +
            "		try\r\n" +
            "		{\r\n" +
            "			EnvDTE.Window window = item.Open();\r\n" +
            "			window.Activate();\r\n" +
            "			\r\n" +
            "			foreach (var cmd in command)\r\n" +
            "			{\r\n" +
            "				if (String.IsNullOrWhiteSpace(cmd) == true)\r\n" +
            "				{\r\n" +
            "					continue;\r\n" +
            "				}\r\n" +
            "				\r\n" +
            "				EnvDTE80.DTE2 dte2 = dte as EnvDTE80.DTE2;\r\n" +
            "				dte2.ExecuteCommand(cmd, String.Empty);		\r\n" +
            "			}\r\n" +
            "			\r\n" +
            "			item.Save();\r\n" +
            "			window.Visible = false;\r\n" +
            "			// window.Close(); // Ends VS, but not the tab :(\r\n" +
            "		}\r\n" +
            "		catch (Exception ex)\r\n" +
            "		{\r\n" +
            "			error = String.Format(\"Error processing file {0} {1}\", item.Name, ex.Message);\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		return error;\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	/// <summary>\r\n" +
            "	/// Sets a property value for the vs project item.\r\n" +
            "	/// </summary>\r\n" +
            "	public static void SetPropertyValue(EnvDTE.ProjectItem item, string propertyName, object value)\r\n" +
            "	{\r\n" +
            "		EnvDTE.Property property = item.Properties.Item(propertyName);\r\n" +
            "		if (property == null)\r\n" +
            "		{\r\n" +
            "			throw new ArgumentException(String.Format(\"The property {0} was not found.\", propertyName));\r\n" +
            "		}\r\n" +
            "		else\r\n" +
            "		{\r\n" +
            "			property.Value = value;\r\n" +
            "		}\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public static IEnumerable<ProjectItem> GetOutputFilesAsProjectItems(EnvDTE.DTE dte, IEnumerable<OutputFile> outputFiles)\r\n" +
            "	{\r\n" +
            "		var fileNames = (from o in outputFiles\r\n" +
            "						select Path.GetFileName(o.FileName)).ToArray();\r\n" +
            "\r\n" +
            "		return VSHelper.GetAllSolutionItems(dte).Where(f => fileNames.Contains(f.Name));\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public static string GetOutputPath(EnvDTE.DTE dte, Block block, string defaultPath)\r\n" +
            "	{\r\n" +
            "		if (String.IsNullOrEmpty(block.ProjectName) == true && String.IsNullOrEmpty(block.FolderName) == true)\r\n" +
            "		{\r\n" +
            "			return defaultPath;\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		EnvDTE.Project prj = null;\r\n" +
            "		EnvDTE.ProjectItem item = null;\r\n" +
            "		\r\n" +
            "		if (String.IsNullOrEmpty(block.ProjectName) == false)\r\n" +
            "		{\r\n" +
            "			prj = GetProject(dte, block.ProjectName);			\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		if (String.IsNullOrEmpty(block.FolderName) == true && prj != null)\r\n" +
            "		{\r\n" +
            "			return Path.GetDirectoryName(prj.FullName);\r\n" +
            "		}\r\n" +
            "		else if (prj != null && String.IsNullOrEmpty(block.FolderName) == false)\r\n" +
            "		{\r\n" +
            "			item = GetAllProjectItemsRecursive(prj.ProjectItems).Where(i=>i.Name == block.FolderName).First();\r\n" +
            "		}\r\n" +
            "		else if (String.IsNullOrEmpty(block.FolderName) == false)\r\n" +
            "		{\r\n" +
            "			item = GetAllProjectItemsRecursive(\r\n" +
            "				dte.ActiveDocument.ProjectItem.ContainingProject.ProjectItems).\r\n" +
            "				Where(i=>i.Name == block.FolderName).First();\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		if (item != null)\r\n" +
            "		{\r\n" +
            "			return GetProjectItemFullPath(item);\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		return defaultPath;\r\n" +
            "	}\r\n" +
            "	public static string GetTemplatePlaceholderName(EnvDTE.ProjectItem item)\r\n" +
            "	{\r\n" +
            "		return String.Format(\"{0}.txt4\", Path.GetFileNameWithoutExtension(item.Name));\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public static EnvDTE.ProjectItem GetTemplateProjectItem(EnvDTE.DTE dte, OutputFile file, EnvDTE.ProjectItem defaultItem)\r\n" +
            "	{\r\n" +
            "		if (String.IsNullOrEmpty(file.ProjectName) == true && String.IsNullOrEmpty(file.FolderName) == true)\r\n" +
            "		{\r\n" +
            "			return defaultItem;\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		string templatePlaceholder = GetTemplatePlaceholderName(defaultItem);\r\n" +
            "		string itemPath = Path.GetDirectoryName(file.FileName); \r\n" +
            "		string fullName = Path.Combine(itemPath, templatePlaceholder);\r\n" +
            "		EnvDTE.Project prj = null;\r\n" +
            "		EnvDTE.ProjectItem item = null;\r\n" +
            "		\r\n" +
            "		if (String.IsNullOrEmpty(file.ProjectName) == false)\r\n" +
            "		{\r\n" +
            "			prj = GetProject(dte, file.ProjectName);			\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		if (String.IsNullOrEmpty(file.FolderName) == true && prj != null)\r\n" +
            "		{\r\n" +
            "			return FindProjectItem(prj.ProjectItems, fullName, true);\r\n" +
            "		}\r\n" +
            "		else if (prj != null && String.IsNullOrEmpty(file.FolderName) == false)\r\n" +
            "		{\r\n" +
            "			item = GetAllProjectItemsRecursive(prj.ProjectItems).Where(i=>i.Name == file.FolderName).First();\r\n" +
            "		}\r\n" +
            "		else if (String.IsNullOrEmpty(file.FolderName) == false)\r\n" +
            "		{\r\n" +
            "			item = GetAllProjectItemsRecursive(\r\n" +
            "				dte.ActiveDocument.ProjectItem.ContainingProject.ProjectItems).\r\n" +
            "				Where(i=>i.Name == file.FolderName).First();\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		if (item != null)\r\n" +
            "		{\r\n" +
            "			return FindProjectItem(item.ProjectItems, fullName, true);\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		return defaultItem;\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	private static EnvDTE.ProjectItem FindProjectItem(EnvDTE.ProjectItems items, string fullName, bool canCreateIfNotExists)\r\n" +
            "	{\r\n" +
            "		EnvDTE.ProjectItem item = (from i in items.Cast<EnvDTE.ProjectItem>()\r\n" +
            "								  where i.Name == Path.GetFileName(fullName)\r\n" +
            "								  select i).FirstOrDefault();\r\n" +
            "		if (item == null)\r\n" +
            "		{\r\n" +
            "			File.CreateText(fullName);\r\n" +
            "			item = items.AddFromFile(fullName);\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		return item;\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public static EnvDTE.Project GetProject(EnvDTE.DTE dte, string projectName)\r\n" +
            "	{\r\n" +
            "		return GetAllProjects(dte).Where(p=>p.Name == projectName).First();\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public static IEnumerable<EnvDTE.Project> GetAllProjects(EnvDTE.DTE dte)\r\n" +
            "	{\r\n" +
            "		List<EnvDTE.Project> projectList = new List<EnvDTE.Project>();\r\n" +
            "		\r\n" +
            "		var folders = dte.Solution.Projects.Cast<EnvDTE.Project>().Where(p=>p.Kind == EnvDTE80.ProjectKinds.vsProjectKindSolutionFolder);\r\n" +
            "\r\n" +
            "		foreach (EnvDTE.Project folder in folders)\r\n" +
            "		{\r\n" +
            "			if (folder.ProjectItems == null) continue;\r\n" +
            "			\r\n" +
            "			foreach (EnvDTE.ProjectItem item in folder.ProjectItems)\r\n" +
            "			{\r\n" +
            "				if (item.Object is EnvDTE.Project)\r\n" +
            "					projectList.Add(item.Object as EnvDTE.Project);\r\n" +
            "			}\r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		var projects = dte.Solution.Projects.Cast<EnvDTE.Project>().Where(p=>p.Kind != EnvDTE80.ProjectKinds.vsProjectKindSolutionFolder);\r\n" +
            "\r\n" +
            "		if (projects.Count() > 0)\r\n" +
            "			projectList.AddRange(projects);\r\n" +
            "		\r\n" +
            "		return projectList;\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public static EnvDTE.ProjectItem GetProjectItemWithName(EnvDTE.ProjectItems items, string itemName)\r\n" +
            "	{\r\n" +
            "		return GetAllProjectItemsRecursive(items).Cast<ProjectItem>().Where(i=>i.Name == itemName).First();\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public static string GetProjectItemFullPath(EnvDTE.ProjectItem item)\r\n" +
            "	{\r\n" +
            "		return item.Properties.Item(\"FullPath\").Value.ToString();\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public static IEnumerable<EnvDTE.ProjectItem> GetAllSolutionItems(EnvDTE.DTE dte)\r\n" +
            "	{\r\n" +
            "		List<EnvDTE.ProjectItem> itemList = new List<EnvDTE.ProjectItem>();\r\n" +
            "\r\n" +
            "		foreach (Project item in GetAllProjects(dte))\r\n" +
            "		{\r\n" +
            "			if (item == null || item.ProjectItems == null) continue;\r\n" +
            "			\r\n" +
            "			itemList.AddRange(GetAllProjectItemsRecursive(item.ProjectItems));	 \r\n" +
            "		}\r\n" +
            "		\r\n" +
            "		return itemList;\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public static IEnumerable<EnvDTE.ProjectItem> GetAllProjectItemsRecursive(EnvDTE.ProjectItems projectItems) \r\n" +
            "	{\r\n" +
            "    	foreach (EnvDTE.ProjectItem projectItem in projectItems) \r\n" +
            "		{\r\n" +
            "			if (projectItem.ProjectItems == null) continue;\r\n" +
            "\r\n" +
            "        	foreach (EnvDTE.ProjectItem subItem in GetAllProjectItemsRecursive(projectItem.ProjectItems))\r\n" +
            "        	{\r\n" +
            "            	yield return subItem;\r\n" +
            "        	}\r\n" +
            "			\r\n" +
            "			\r\n" +
            "        	yield return projectItem;\r\n" +
            "    	}\r\n" +
            "	}\r\n" +
            "}\r\n" +
            "\r\n" +
            "public sealed class OutputFile\r\n" +
            "{\r\n" +
            "	public OutputFile()\r\n" +
            "	{\r\n" +
            "		this.FileProperties = new FileProperties\r\n" +
            "		{\r\n" +
            "			CustomTool = String.Empty,\r\n" +
            "			BuildAction = BuildAction.None\r\n" +
            "		};\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public string FileName { get; set; }\r\n" +
            "	public string ProjectName { get; set; }\r\n" +
            "	public string FolderName { get; set; }\r\n" +
            "	public string Content { get; set; }\r\n" +
            "	public FileProperties FileProperties { get; set; }\r\n" +
            "}\r\n" +
            "\r\n" +
            "public class BuildAction\r\n" +
            "{\r\n" +
            "	public const string None = \"None\";\r\n" +
            "	public const string Compile = \"Compile\";\r\n" +
            "	public const string Content = \"Content\";\r\n" +
            "	public const string EmbeddedResource = \"EmbeddedResource\";\r\n" +
            "	public const string EntityDeploy = \"EntityDeploy\";\r\n" +
            "}\r\n" +
            "\r\n" +
            "public sealed class FileProperties\r\n" +
            "{\r\n" +
            "	public FileProperties ()\r\n" +
            "	{\r\n" +
            "		this.TemplateParameter = new Dictionary<string,string>();	\r\n" +
            "	}\r\n" +
            "	\r\n" +
            "	public string CustomTool { get; set; }\r\n" +
            "	public string BuildAction { get; set; }\r\n" +
            "	public Dictionary<string, string> TemplateParameter { get; set; }\r\n" +
            "	\r\n" +
            "	internal string BuildActionString\r\n" +
            "	{\r\n" +
            "		get\r\n" +
            "		{\r\n" +
            "			return this.BuildAction;\r\n" +
            "		}\r\n" +
            "	}\r\n" +
            "}\r\n" +
            "\r\n" +
            "\r\n" +
            "#>\r\n";
    }
}
