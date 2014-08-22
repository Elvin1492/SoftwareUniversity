<?php

function nonrepeating_digit($number){
	$output = array();
	for ($i = 102; $i <= $number ; $i++) {
		if($i > 987){
			break;
		} 
		$ones =  $i % 10;
		$hundreds = (floor($i / 10) % 10);
		$thousands = floor($i / 100);
		if(($ones != $hundreds) && ($hundreds != $thousands) && ($thousands != $ones)){
			array_push($output, $i);
		}		
	}
	if(count($output) > 0){
		return implode(" ", $output);
	} else{
		return 'no';
	}
}
	
echo nonrepeating_digit(1234);
echo(PHP_EOL);
echo nonrepeating_digit(145);
echo(PHP_EOL);
echo nonrepeating_digit(15);
echo(PHP_EOL);
echo nonrepeating_digit(247);
echo(PHP_EOL);

?>