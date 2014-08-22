<!DOCTYPE html>
<html>
	<head>
		<title>Tags counter</title>
		<meta charset='UTF-8' />
	</head>
	<body>
		<form method="post" action="<?php $_PHP_SELF ?>">
			<label for="tag">Enter HTML tags:</label><br/>
			<input type="text" name="tag" id="tag" />
			<input type="submit" name="submit" />			
		</form><br/>	   
		<?php	
		if(isset($_POST['tag']))
		{
		  session_start();
		  $valid_tags = array("!DOCTYPE", "a", "abbr", "acronym", "address", "applet", "area", "article", "aside", "audio", "b", "base", 
		  "basefont", "bdi", "bdo", "big", "blockquote", "body", "br", "button", "canvas", "caption", "center", "cite", "code", "col", 
		  "colgroup", "command", "datalist", "dd", "del", "details", "dfn", "dir", "div", "dl", "dt", "em", "embed", "fieldset", "figcaption",
		   "figure", "font", "footer", "form", "frame", "frameset", "h1", "h2", "h3", "h4", "h5", "h6", "head", "header", "hgroup", "hr", 
		   "html", "i", "iframe", "img", "input", "ins", "kbd", "keygen", "label", "legend", "li", "link", "map", "mark", "menu", "meta", 
		   "meter", "nav", "noframes", "noscript", "object", "ol", "optgroup", "option", "output", "p", "param", "pre", "progress", "q", "rp", 
		   "rt", "ruby", "s", "samp", "script", "section", "select", "small", "source", "span", "strike", "strong", "style", "sub", 
		   "summary", "sup", "table", "tbody", "td", "textarea", "tfoot", "th", "thead", "time", "title", "tr", "track", "tt", "u", "ul", 
		   "var", "video", "wbr");	
		   
		  $entered_tags = array();	
		  $tag = strtolower($_POST['tag']);
		  
		  if(in_array($tag, $valid_tags)){	
			$_SESSION['count']++;
		  	echo "<p><bold>Valid HTML Tag!</bold></p>";
		    echo "Score:".  $_SESSION['count'];	
		  } else {
		  	echo "<p><bold>Invalid HTML Tag!</bold></p>";
			echo "Score:".  $_SESSION['count'];
		  }
		}		
		?>		
	</body>
</html>
