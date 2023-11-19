<#
.SYNOPSIS
Implement a simple shift cipher like Caesar and a more secure substitution cipher.

.DESCRIPTION
Implement a simple cipher class to encode or decode a message with a key.
If there was no key provided, generate one minumum 100 characters long contains only lower case letter (a-z).

.EXAMPLE
$cipher = [SimpleCipher]::new("mykey")

$cipher.Encode("aaaaa")
Return: "mykey"

$cipher.Decode("ecmvcf")
Return: "secret"
#>

Class SimpleCipher {
    $_key
    static [string] $Alphabet = "abcdefghijklmnopqrstuvwxyz"

    SimpleCipher() {
        $r = new-object System.Random
        $this._key =  [String]::Join("", (1..100 | % { [char]$r.next(97, 122) }))
    }

    SimpleCipher([string]$key) {
        $this._key = $key;
    }

    [string] Encode([string]$plaintext) {
        $ciphertext = ""
        for ( ($i = 0), ($j = 0); $i -lt $plaintext.length; ($i++), ($j = $i % $this._key.Length)) {
            $ciphertext += [SimpleCipher]::Alphabet[($this.Distance($this._key[$j]) + $this.Distance($plaintext[$i])) % 26]
        }
        return $ciphertext;
    }

    [string] Decode([string]$ciphertext) {
        $plaintext = ""
        for ( ($i = 0), ($j = 0); $i -lt $ciphertext.length; ($i++), ($j = $i % $this._key.Length)) {
            $plaintext += [SimpleCipher]::Alphabet[($this.Distance($ciphertext[$i]) - $this.Distance($this._key[$j]) + 26) % 26]
        }
        return $plaintext
    }


    [int] Distance([char]$c) {
        return [SimpleCipher]::Alphabet.IndexOf($c)
    }
}