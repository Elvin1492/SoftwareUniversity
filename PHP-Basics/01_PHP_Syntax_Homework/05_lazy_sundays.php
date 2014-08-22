<?php

function lazy_sunday(){
	$output = array();
	$month = date('F');
	$days =  date('t');
	$year = date('Y');
	for($i = 1; $i<= $days; $i++){
		$date = strtotime("$i $month $year");
		if(date('l', $date) == 'Sunday'){
			$dt = date('jS F, Y',$date);
			array_push($output,$dt);
		}
	}
	
	return implode( "\n" , $output);
	
}
echo lazy_sunday();


?>