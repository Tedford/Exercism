package Darts;

use v5.38;
use Math::Complex;
use Exporter qw<import>;
our @EXPORT_OK = qw<score_dart>;

sub score_dart ( $x, $y ) {
    my $dist = sqrt($x**2 + $y**2);
    my $result = 0;

    if( $dist <= 1)
    {
        $result = 10;
    }elsif( $dist <= 5){
        $result = 5;
    }
    elsif($dist <=10){
        $result = 1;
    }
    return $result;
}
