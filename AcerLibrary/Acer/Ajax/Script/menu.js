//****************************************************************
// You are free to copy the "Folder-Tree" script as long as you
// keep this copyright notice:
// Script found in: http://www.geocities.com/Paris/LeftBank/2178/
// Author: Marcelino Alves Martins (martins@hks.com) December '97.
//****************************************************************

//Log of changes:
//       17 Feb 98 - Fix initialization flashing problem with Netscape
//
//       27 Jan 98 - Root folder starts open; support for USETEXTLINKS;
//                   make the ftien4 a js file
//

// Definition of class Folder
// *****************************************************************

function Folder(folderDescription, hreference, type_id) //constructor
{
	//constant data
	this.desc	=	folderDescription;
	this.hreference	=	hreference;
	this.type_id	=	type_id;
	this.id		=	-1;
	this.navObj	=	0;
	this.iconImg	=	0;
	this.nodeImg	=	0;
	this.isLastNode	=	0;

	//dynamic data
	this.isOpen	=	true;
	this.iconSrc	=	"images/ftv2folderopen.gif";
	this.children	=	new Array;
	this.nChildren	=	0;

	//methods
	this.initialize	=	initializeFolder;
	this.setState	=	setStateFolder;
	this.addChild	=	addChild;
	this.createIndex=	createEntryIndex;
	this.hide	=	hideFolder;
	this.display	=	display;
	this.renderOb	=	drawFolder;
	this.totalHeight=	totalHeight;
	this.subEntries	=	folderSubEntries;
	this.outputLink	=	outputFolderLink;
}

function setStateFolder(isOpen)
{
	var	subEntries
	var	totalHeight
	var	fIt	=	0
	var	i	=	0

	if (isOpen == this.isOpen)
		return

	this.isOpen	=	isOpen
	propagateChangesInState(this)
}

function propagateChangesInState(folder)
{
	var	i	=	0

	if (folder.isOpen)
	{
		if (folder.nodeImg)
			if (folder.isLastNode)
				folder.nodeImg.src	=	"images/ftv2mlastnode.gif"
			else
				folder.nodeImg.src	=	"images/ftv2mnode.gif"
		folder.iconImg.src	=	"images/ftv2folderopen.gif"
		for (i = 0; i < folder.nChildren; i++)
			folder.children[i].display()
	}
	else
	{
		if (folder.nodeImg)
			if (folder.isLastNode)
				folder.nodeImg.src	=	"images/ftv2plastnode.gif"
			else
				folder.nodeImg.src	=	"images/ftv2pnode.gif"
		folder.iconImg.src	=	"images/ftv2folderclosed.gif"
		for (i = 0; i < folder.nChildren; i++)
			folder.children[i].hide()
	}
}

function hideFolder()
{
	if (this.navObj.style.display == "none")
		return
	this.navObj.style.display	=	"none"

	this.setState(0)
}

function initializeFolder(level, lastNode, leftSide)
{
	var	j	=	0
	var	i	=	0
	var	numberOfFolders
	var	numberOfDocs
	var	nc

	nc	=	this.nChildren

	this.createIndex()

	var	auxEv	=	""

	auxEv	=	"<a href='javascript:clickOnNode("+this.id+")'>"
	
	if (level>0)
		if (lastNode) //the last 'brother' in the children array
		{
			this.renderOb(leftSide + auxEv + "<img alt='' name='nodeIcon" + this.id + "' src='images/ftv2mlastnode.gif' width=16 height=22 border=0 ></a>")
			leftSide	=	leftSide + "<img src='images/ftv2blank.gif' width=16 height=22>"
			this.isLastNode	=	1
		}
		else
		{
			this.renderOb(leftSide + auxEv + "<img name='nodeIcon" + this.id + "' src='images/ftv2mnode.gif' width=16 height=22 border=0 ></a>")
			leftSide	=	leftSide + "<img src='images/ftv2vertline.gif' width=16 height=22>"
			this.isLastNode	=	0
		}
	else
		this.renderOb("")

	if (nc > 0)
	{
		level	=	level + 1
		for (i=0 ; i < this.nChildren; i++)
		{
			if (i == this.nChildren-1)
				this.children[i].initialize(level, 1, leftSide)
			else
				this.children[i].initialize(level, 0, leftSide)
		}
	}
}

function drawFolder(leftSide)
{
	doc.write("<table ")
	doc.write(" id='folder" + this.id + "' style='position:block;' ")
	doc.write(" border=0 cellspacing=0 cellpadding=0>")
	doc.write("<tr><td>")
	doc.write(leftSide)
	this.outputLink()

	if (this.hreference)
	{
		doc.write("<img  alt=''name='folderIcon" + this.id + "' ")
		doc.write("src='" + this.iconSrc+"' border=0>")
	}
	else
	{
		doc.write("<a href='javascript:clickOnNode(" + this.id + ")'>" + "<img alt='' name='folderIcon" + this.id + "' ")
		doc.write("src='" + this.iconSrc+"' border=0></a>")
	}

	doc.write("</td><td valign=middle nowrap>")
	if (USETEXTLINKS)
	{
		this.outputLink()
		if (this.hreference)
			doc.write(this.desc)
		else
			doc.write("<a href='javascript:clickOnNode(" + this.id + ")'>" + this.desc + "</a>")
	}
	else
		doc.write(this.desc)
	doc.write("</td>")
	doc.write("</table>")

	this.navObj	=	doc.all["folder"+this.id]
	this.iconImg	=	doc.all["folderIcon"+this.id]
	this.nodeImg	=	doc.all["nodeIcon"+this.id]
}

function outputFolderLink()
{
	if (this.hreference)
	{
		//2000 11 18 ERNIE WONG doc.write("<a href='" + this.hreference + "' TARGET='_self' ")
		doc.write("<a href='" + this.hreference + "' TARGET='_top' ")
		doc.write("onClick='javascript:clickOnFolder("+this.id+")'")
		doc.write(">")
	}
	else
		doc.write("<a>")
	//  doc.write("<a href='javascript:clickOnFolder("+this.id+")'>")
}

function addChild(childNode)
{
	this.children[this.nChildren]	=	childNode;
	this.nChildren++;
	return childNode;
}

function folderSubEntries()
{
	var	i	=	0
	var	se	=	this.nChildren

	for (i=0; i < this.nChildren; i++)
	{
		if (this.children[i].children) //is a folder
			se	=	se + this.children[i].subEntries()
	}

	return se
}


// Definition of class Item (a document or link inside a Folder)
// *************************************************************

function Item(itemDescription, itemLink, type_id) // Constructor
{
	// constant data
	this.desc	=	itemDescription;
	this.link	=	itemLink;
	this.type_id	=	type_id;
	this.id		=	-1;	//initialized in initalize()
	this.navObj	=	0;	//initialized in render()
	this.iconImg	=	0;	//initialized in render()
	this.iconSrc	=	"images/ftv2doc.gif";

	// methods
	this.initialize	=	initializeItem;
	this.createIndex=	createEntryIndex;
	this.hide	=	hideItem;
	this.display	=	display;
	this.renderOb	=	drawItem;
	this.totalHeight=	totalHeight;
}

function hideItem()
{
	if (this.navObj.style.display == "none")
		return
	this.navObj.style.display	=	"none"
}

function initializeItem(level, lastNode, leftSide)
{
	this.createIndex()

	if (level>0)
		if (lastNode) //the last 'brother' in the children array
		{
			this.renderOb(leftSide + "<img src='images/ftv2doc.gif' width=17 height=22>")
			leftSide	=	leftSide + "<img src='images/ftv2blank.gif' width=16 height=22>"
		}
		else
		{
			this.renderOb(leftSide + "<img src='images/ftv2doc.gif' width=17 height=22>")
			leftSide	=	leftSide + "<img src='images/ftv2vertline.gif' width=16 height=22>"
		}
	else
		this.renderOb("")
}

function drawItem(leftSide)
{
	doc.write("<table ")
	doc.write(" id='item" + this.id + "' style='position:block;' ")
	doc.write
	(
		" border=0 cellspacing=0 cellpadding=0>" +
		"<tr>" +
			"<td>" + leftSide + "</td>" +
		"<td valign=middle nowrap>"
	);
	if (USETEXTLINKS)
		doc.write
		(
			"<a href=" + this.link + " title='" + this.desc + "'" +
			"onclick=\"setColor(this);top.hideView();top.mainFrame.document.write('Page loading...');\">" + 
			this.desc + 
			"</a>"
		);
	else
		doc.write(this.desc)
	doc.write("</table>")

	this.navObj	=	doc.all["item"+this.id]
	this.iconImg	=	doc.all["itemIcon"+this.id]
}

function setColor(linkObj)
{
	var	links	=	document.getElementsByTagName("a");
	for (var i = 0; i < links.length; i++)
	{
		links[i].style.color	=	'';
		links[i].style.fontWeight	=	'';
	}
	linkObj.style.color		=	'red';
	linkObj.style.fontWeight	=	'bold';
	
}

// Methods common to both objects (pseudo-inheritance)
// ********************************************************

function display()
{
	this.navObj.style.display	=	"block"
}

function createEntryIndex()
{
	this.id	=	nEntries
	indexOfEntries[nEntries]	=	this
	nEntries++
}

// total height of subEntries open
function totalHeight() //used with browserVersion == 2
{
	var	h	=	this.navObj.clip.height
	var	i	=	0

	if (this.isOpen) //is a folder and _is_ open
		for (i=0 ; i < this.nChildren; i++)
			h	=	h + this.children[i].totalHeight()

	return h
}


// Events
// *********************************************************

function clickOnNode(folderId)
{
	var	clickedFolder	=	0
	var	state	=	0

	clickedFolder	=	indexOfEntries[folderId]
	state		=	clickedFolder.isOpen

	clickedFolder.setState(!state) //open<->close
}

function initializeDocument()
{
	foldersTree.initialize(0, 1, "")
	foldersTree.display()
	
	// close the whole tree
	clickOnNode(0)
	// open the root folder
	clickOnNode(0)
	//??璆剖?鞈?蝬剛風
	clickOnNode(1)
}

// Auxiliary Functions for Folder-Treee backward compatibility
// *********************************************************

function gFld(description, hreference, type_id)
{
	return new Folder(description, hreference, type_id);
}

function gLnk(description, linkData, type_id)
{
	var	fullLink	=	"'" + linkData + "' target='mainFrame'";
	return new Item(description, fullLink, type_id);
}

function insFld(parentFolder, childFolder)
{
	return parentFolder.addChild(childFolder);
}

function insDoc(parentFolder, document)
{
	parentFolder.addChild(document);
}

// Global variables
// ****************
USETEXTLINKS	=	1
indexOfEntries	=	new Array
nEntries	=	0
doc		=	document
selectedFolder	=	0
strTitle	=	''

var	strChoice;
strChoice	=	'';

function fnAdd_choice(this_checkbox,l_type_id)
{
	var	choice_value;
	choice_value	=	strChoice;

	if (this_checkbox.checked)
	{
		choice_value	=	choice_value + l_type_id + ',';
	}
	else
	{
		choice_value	=	replaceString(choice_value,(l_type_id+','),'');
	}

	strChoice	=	choice_value;

	return;
}

function replaceString(str, from, to)
{
	// replaces "from" with "to" in str and returns the result
	//
	// Parameters:
	// str: string in which the replacements should take place
	// from: the string to replace
	// to: the string to replace it with.
	//
	// Author: Gerald Benischke
	//
	if (from == "") return str

	var	pos
	var	prestring
	var	poststring

	pos	=	str.indexOf(from)

	while (pos != -1)
	{
		prestring	=	str.substring(0, pos)
		poststring	=	str.substring(pos + from.length, str.length)
		str		=	prestring + to + poststring

		pos		=	str.indexOf(from, pos + from.length - 1)
	}

	return str
}
