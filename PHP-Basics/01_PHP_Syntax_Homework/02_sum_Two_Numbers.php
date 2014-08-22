<?php

function sum_two_numbers($a, $b){
	return round($a + $b,2);
}

echo sum_two_numbers(2, 5);
echo(PHP_EOL);
echo sum_two_numbers(1.567808, 0.356);
echo(PHP_EOL);
echo sum_two_numbers(1234.5678,333);
echo(PHP_EOL);

?>