<?php

function dump_variable($variable){
	if(gettype($variable) == "integer" || gettype($variable) == "double"){
		return var_dump($variable);
	}else {
		return gettype($variable);
	}
}
 
echo dump_variable("hello");
echo(PHP_EOL);
echo dump_variable(15);
echo(PHP_EOL);
echo dump_variable(1.234);
echo(PHP_EOL);
echo dump_variable(array(1,2,3));
echo(PHP_EOL);
echo dump_variable((object)[2,34]);
echo(PHP_EOL);

?>