<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128632209/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3193)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DifferentRepositoriesProgressBar.cs](./CS/ColoredProgressBar/DifferentRepositoriesProgressBar.cs) (VB: [DifferentRepositoriesProgressBar.vb](./VB/ColoredProgressBar/DifferentRepositoriesProgressBar.vb))
* [Form1.cs](./CS/ColoredProgressBar/Form1.cs) (VB: [Form1.vb](./VB/ColoredProgressBar/Form1.vb))
* [Program.cs](./CS/ColoredProgressBar/Program.cs) (VB: [Program.vb](./VB/ColoredProgressBar/Program.vb))
* [SingleRepositoryProgressBar.cs](./CS/ColoredProgressBar/SingleRepositoryProgressBar.cs) (VB: [SingleRepositoryProgressBar.vb](./VB/ColoredProgressBar/SingleRepositoryProgressBar.vb))
<!-- default file list end -->
# How to use different colored ProgressBar in GridControl


<p>Our GridControl has a very flexible architecture, so this task can be accomplished using several approaches. <br />
So, if you need your ProgressBar in a cell to have consistent appearance with standalone controls and want to be able to print or export them, we suggest you use the solution described in approach #1 case 2.<br />
If you want to draw a complex progress bar with a custom content or display any other editor over ProgressBar, you can use the solution described in approach #2.</p><p><strong>Approach </strong><strong>#</strong><strong>1</strong><strong>.</strong> Using the standard RepositoryItemProgressBars with some additional handling:<br />
    <strong>Case 1</strong><strong>.</strong> Use different RepositoryItems with different settings for each color in ProgressBar (the "Different RepositoryItems" column in the example) and pass them to different cells via the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsGridGridView_CustomDrawCelltopic"><u>GridView.CustomDrawCell Event</u></a>.<br />
        <strong>Advantages:</strong> After creating all necessary RepositoryItems, they only need to be passed via the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsGridGridView_CustomRowCellEdittopic"><u>GridView.CustomRowCellEdit Event</u></a> based on your logic. So, your code will be easily understandable.<br />
        <strong>Disadvantages:</strong><strong> </strong>The RepositoryItems initialization code can be long if you need to have a lot of different colors, because you need to initialize each RepositoryItem. To reduce this code, you can copy a RepositoryItem's settings using the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsRepositoryRepositoryItem_Assigntopic"><u>RepositoryItem.Assign Method</u></a>. Also, you can store appearance settings in some array, so you can traverse  through all appearance objects and assign them to RepositoryItems in a loop.  <br />
        All created repository items will be stored in memory. So, if you need to have many colors, it is better to use the approach described in case 2. <br />
    <strong>Case 2</strong><strong>.</strong> Using a single RepositoryItem with handling the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsGridGridView_CustomDrawCelltopic"><u>GridView.CustomDrawCell</u></a> and<strong> </strong><a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnView_ShownEditortopic"><u>ColumnView.ShownEditor</u></a> events (the "Single RepositoryItem" column in the example). <br />
        <strong>Advantages:</strong>  Using a single RepositoryItem reduces the amount of initialization code. it gives more efficient memory usage than in Case 1.</p><p><strong>Approach </strong><strong>#</strong><strong>2</strong><strong>.</strong> Manually draw ProgressBar in cells.<br />
    <strong>Advantages:</strong> Provides the capability to draw ProgressBar in a cell's background and draw a custom ProgressBar. I.e. custom drawing gives you full control over a cell's content, and you can draw anything that you want.<br />
    <strong>Disadvantages:</strong>  The main disadvantage is that a custom drawn content <strong>cannot be printed and exported. </strong>See the <a href="https://www.devexpress.com/Support/Center/p/A1498">Is custom drawing ignored when printing or exporting?</a> KB article.  <br />
    It requires manual editors drawing, and elaborate editors and focus rectangles drawing.      <br />
Custom drawing can be implemented in several (optional) steps:<br />
    <strong>Step 1</strong>: Draw cell focus and highlighting (the "Manual Draw Without Editor" column in the example).<br />
    <strong>Step 2</strong>: Manual ProgressBar drawing in the<strong> </strong><a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsGridGridView_CustomDrawCelltopic"><u>GridView.CustomDrawCell Event</u></a> handler. In this case, ProgressBar is drawn in an editor's background, but if the editor become focused, then the editor's background covers the custom drawn ProgressBar (the "Manual Draw not in Focus" column in the example). To avoid this, lock cell focusing by setting the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridColumnsOptionsColumn_AllowFocustopic"><u>OptionsColumn.AllowFocus Property</u></a> to false (the "Manual Draw Without Focus" column in the example) or use the e.Handled parameter as described in the next step.<br />
    <strong>Step 3</strong>: Set the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseCustomDrawEventArgs_Handledtopic"><u>CustomDrawEventArgs.Handled Property</u></a> to true in the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsGridGridView_CustomDrawCelltopic"><u>GridView.CustomDrawCell Event</u></a> handler. After this, the default drawing will not be performed. <br />
    <strong>Part 4</strong> : If it is necessary, draw a required content over your ProgressBar. You can draw any our editor using a corresponding painter. The SpinEdit is drawn in the "Manual Draw With Editor" column in the example.</p><p>Please note that when you click a cell, we create an in-place editor, which is a control. Since using this approach we just draw a required content directly on GridControl, this active editor will overlap our custom drawn progress bar. You can use this functionality to implement editing in your progress bar column. If you do not need this functionality, just disable the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridColumnsOptionsColumn_AllowEdittopic"><u>OptionsColumn.AllowEditt</u></a> option. </p><p></p>

<br/>


