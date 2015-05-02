//// JScript File
var DIV_BG_COLOR = "#eaeaea";
var DIV_HIGHLIGHT_COLOR = "#66CCFF";
var DIV_FONT = "Arial";
var DIV_PADDING = "2px";
var DIV_BORDER = "1px solid #CCC";
var queryField;
var divName;
var ifName;
var lastVal = "";
var val = "";
var globalDiv;
var divFormatted = false;

function InitQueryCode( queryFieldName, hiddenDivName )
{    
    queryField = document.getElementById( queryFieldName );
    queryField.onblur = hideDiv;
    queryField.onkeydown = keypressHandler;
    queryField.autocomplete = "off";
    
    if( hiddenDivName )
    {
        divName = hiddenDivName;
    }
    else
    {
        divName = "querydiv";
    }
    
    ifName = "queryiframe";
    setTimeout("mainLoop()",100);
}

function getDiv(divID)
{
    if(!globalDiv)
    {
        if(!document.getElementById(divID))
        {
            var newNode = document.createElement("div");
            newNode.setAttribute("id", divID);
            document.body.appendChild(newNode);
        }
        globalDiv = document.getElementById(divID);
        var x = queryField.offsetLeft;
        var y = queryField.offsetTop + queryField.offsetHeight;
        var parent = queryField;
        while(parent.offsetParent)
        {
            parent = parent.offsetParent;
            x += parent.offsetLeft;
            y += parent.offsetTop;
        }
        if(!divFormatted)
        {
            globalDiv.style.backgroundColor = DIV_BG_COLOR;
            globalDiv.style.fontFamily = DIV_FONT;
            globalDiv.style.padding = DIV_PADDING;
            globalDiv.style.border = DIV_BORDER;
            globalDiv.style.minwidth = "150px";
            globalDiv.style.fontSize = "12px";            
            globalDiv.style.position = "absolute";
            globalDiv.style.left = x + "px";
            globalDiv.style.top = y + "px";
            globalDiv.style.visibility = "hidden";
            globalDiv.style.zIndex =10001;
            divFormatted = true;
			
        }
    }
    return globalDiv;
}

function showQueryDiv(resultArray)
{
    var div = getDiv(divName);
    while( div.childNodes.length > 0 )
    {
        div.removeChild(div.childNodes[0]);
    }
    for(var i = 0; i < resultArray.length/2; i++)
    {
        var result = document.createElement("div");
        result.style.cursor = "pointer";
        result.style.padding = "2px 0px 2px 0px";
        result.style.minwidth = div.style.width; //Add width
        result.style.height = "15px";  
        _unhighlightResult(result);
        result.onmousedown = selectResult;
        result.onmouseover = highlightResult;
        result.onmouseout = unhighlightResult;        
        
        var value = document.createElement("span");
        value.className = "value1";
        value.style.textAlign = "left";
        value.style.fontWeight = "bold";
        value.style.float = "left";
        value.innerHTML = unescape(resultArray[resultArray.length / 2 + i]);
        result.appendChild(value);
        var value1 = document.createElement("span");
        value1.className = "value";
        value1.style.textAlign = "left";
        value1.style.fontWeight = "bold";
        value1.style.float = "right";
        value1.innerHTML = unescape(resultArray[i]);
        result.appendChild(value1);





        div.appendChild(result);
        
                
    }
    showDiv(resultArray.length/2 > 0);
}

function selectResult()
{
    _selectResult(this);
}
function _selectResult( item )
{
    var spans = item.getElementsByTagName("span");
    if( spans )
    {
        for(var i = 0; i < spans.length; i++)
        {
            if( spans[i].className == "value" )
            {
                queryField.value = spans[i].innerHTML; //.split("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")[1]
                lastVar = val =escape(queryField.value);
                mainLoop();
                queryField.focus();
                showDiv( false );
                return;
            }
        }
    }
}

function highlightResult()
{
    _highlightResult( this );    
}

function _highlightResult( item )
{
    item.style.backgroundColor = DIV_HIGHLIGHT_COLOR;
    item.style.height='15px';
}

function unhighlightResult()
{
    _unhighlightResult( this );
}

function _unhighlightResult( item )
{
    item.style.backgroundColor = DIV_BG_COLOR;
}

function showDiv( show )
{
    var div = getDiv( divName );
    if( show )
    {
        div.style.visibility = "visible";
    }
    else
    {
        div.style.visibility = "hidden";
    }
//    adjustiFrame();
}

function hideDiv()
{
    showDiv( false );
}

function keypressHandler(evt)
{
    var div = getDiv( divName );
    if( div.style.visibility == "hidden" )
    {
        return true;
    }
    if( !evt && window.event )
    {
        evt = window.event;
    }
    var key = evt.keyCode;
    
    var KEYUP = 38;
    var KEYDOWN = 40;
    var KEYENTER = 13;
    var KEYTAB = 9;
    if(( key != KEYUP ) && ( key != KEYDOWN ) && ( key != KEYENTER ) && ( key != KEYTAB ))
    {
        return true;
    }
    var selNum = getSelectedSpanNum( div );
    var selSpan = setSelectedSpan( div, selNum );
    if( key == KEYENTER || key == KEYTAB )
    {
        if( selSpan )
        {
            _selectResult(selSpan);
        }
        evt.cancelBubble= true;
        return false;
    }    
    else
    {
        if( key == KEYUP)
        {
            selSpan = setSelectedSpan( div, selNum - 1 );           
        }
        if( key == KEYDOWN )
        {
            selSpan = setSelectedSpan( div, selNum + 1 );
        }
        if( selSpan )
        {
            _highlightResult( selSpan );
        }
    }
    showDiv( true );
    return true;
}

function getSelectedSpanNum( div )
{
    var count = -1;
    var spans = div.getElementsByTagName("div");
    if( spans )
    {
        for( var i = 0; i < spans.length; i++)
        {
            count++;
            if( spans[i].style.backgroundColor != div.style.backgroundColor )
            {
                return count;
            }
        }
    }
    return -1;
}
function setSelectedSpan( div, spanNum )
{
    var count = -1;
    var thisDiv;
    var divs = div.getElementsByTagName("div");
    if( divs )
    {
        for( var i = 0; i < divs.length; i++ )
        {
            if( ++count == spanNum )
            {
                _highlightResult( divs[i] );
                thisDiv = divs[i];
            }
            else
            {
                _unhighlightResult( divs[i] );
            }
        }        
    }
    return thisDiv;
}

function adjustiFrame() {
    if (!document.getElementById(ifName)) {
        var newNode = document.createElement("iFrame");
        newNode.setAttribute("id", ifName);
        newNode.setAttribute("src", "javascript:void(0);");
        newNode.setAttribute("scrolling", "no");
        newNode.setAttribute("frameborder", "0");
        document.body.appendChild(newNode);
    }
    iFrameDiv = document.getElementById(ifName);
    var div = getDiv(divName);
    try {
        iFrameDiv.style.position = "absolute";
        iFrameDiv.style.width = div.offsetWidth;
        iFrameDiv.style.height = div.offsetHeight;

        iFrameDiv.style.top = div.style.top;
        iFrameDiv.style.left = div.style.left;
        iFrameDiv.style.zIndex = div.style.zIndex -1;
        iFrameDiv.style.visibility = div.style.visibility;
    }
    catch (e)
    { }
}