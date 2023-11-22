package AtbashCipher;

use v5.38;

use Exporter qw<import>;
our @EXPORT_OK = qw<encode_atbash decode_atbash>;


my $plain = "abcdefghijklmnopqrstuvwxyz";
my $cipher = "zyxwvutsrqponmlkjihgfedcba";

sub encode_atbash ($phrase) {
    $phrase = lc($phrase);
    my $buffer = "";
    foreach my $c (split('',$phrase)) {
        if ( $c =~ /\d/ ){
            $buffer .= $c;
        }elsif ($c =~ /\w/){
            $buffer .= substr($cipher, index($plain,$c),1);
        }
    }
    my $chunking = 1;
    my $i = 0;
    my $ciphertext = "";
    while( $chunking) {
        if ($i > 0){
            $ciphertext .= " ";
        }
        $ciphertext .= substr($buffer, $i, 5);
        $i += 5;
        $chunking = $i < length($buffer);
    }

    return $ciphertext;
}

sub decode_atbash ($phrase) {
    my $plaintext= "";

    foreach my $c (split('',$phrase))
    {
        if( $c =~ /\d/){
            $plaintext .= $c;
        }elsif ($c =~ /\w/){
            $plaintext .= substr($plain, index($cipher,$c),1);
        }
    }
    return $plaintext;
}
