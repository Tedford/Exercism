(module
  (memory (export "mem") 1)

  ;;
  ;; Count the number of each nucleotide in a DNA string.
  ;;
  ;; @param {i32} offset - The offset of the DNA string in memory.
  ;; @param {i32} length - The length of the DNA string.
  ;;
  ;; @returns {(i32,i32,i32,i32)} - The number of adenine, cytosine, guanine, 
  ;;                                and thymine nucleotides in the DNA string
  ;;                                or (-1, -1, -1, -1) if the DNA string is
  ;;                                invalid.
  ;;
  (func (export "countNucleotides") (param $offset i32) (param $length i32) (result i32 i32 i32 i32)
    (local $i i32)
    (local $current i32)
    (local $adenine i32)
    (local $cytosine i32)
    (local $guanine i32)
    (local $thymine i32)


    (if (i32.lt_u (local.get $i) (local.get $length)) 
      (then
        (loop
          ;; walk the string
          (local.set  $current (i32.load8_u (i32.add (local.get $offset) (local.get $i)))

          ;; accumulate or exit
          (if (i32.eq (local.get $current) (i32.const 65)) 
            (then (local.set $adenine (i32.add (local.get $adenine) (i32.const 1))))
          (else (if (i32.eq (local.get $current) (i32.const 67)) 
            (then (local.set $cytosine (i32.add (local.get $cytosine) (i32.const 1))))
          (else (if (i32.eq (local.get $current) (i32.const 71)) 
            (then (local.set $guanine (i32.add (local.get $guanine) (i32.const 1)))) 
          (else (if (i32.eq (local.get $current) (i32.const 84)) 
            (then (local.set $thymine (i32.add (local.get $thymine) (i32.const 1)))) 
          (else (return (i32.const -1) (i32.const -1) (i32.const -1) (i32.const -1))) )))))

          ;; increment
          (br_if 0 (i32.lt_u (local.tee $i (i32.add (local.get $i) (i32.const 1))) (local.get $length)))
        )
      )
    )

    (return 
      (local.get $adenine)
      (local.get $cytosine)
      (local.get $guanine)
      (local.get $thymine)
    )
  )
)
