package Series;

use v5.38;

use Exporter qw<import>;
our @EXPORT_OK = qw<slices>;

sub slices ( $series, $slice_length ) {

    if( $slice_length == 0){
        die "slice length cannot be zero";
    } elsif ($slice_length < 0 ) {
        die "slice length cannot be negative";
    }
    if( length($series)== 0){
        die "series cannot be empty";
    }
    if ($slice_length> length($series)){
        die "slice length cannot be greater than series length";
    }

    my @values = ();
    
    for ( my $i = 0; $i < length($series) + 1 - $slice_length; $i++ ) {
        push(@values, substr($series, $i, $slice_length));
    }

    return \@values;
}
