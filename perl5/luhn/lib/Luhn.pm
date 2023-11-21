package Luhn;

use v5.38;
use Exporter qw<import>;
our @EXPORT_OK = qw<is_luhn_valid>;

sub is_luhn_valid ($number) {
    my $valid = 0;
    $number =~ s/\s+//g;

    if( length($number) > 1 && $number =~ /^\d+$/)
    {
        my $crc = 0;
        my $double = 0;
        foreach my $c (split('',reverse($number))){
            if ($c =~ /\d/) {
                if ($double){
                    my $d = $c * 2;
                    if( $d > 9){
                        $d -= 9;
                    }
                    $crc += $d;  
                }
                else {
                    $crc += $c;
                }
                $double = !$double;
            }
        }
        $valid = ($crc % 10) == 0 && length($number) > 1;
    }

    return $valid
}
