(module
  (memory (export "mem") 1)

  ;;
  ;; Encrypt plaintext using the rotational cipher.
  ;;
  ;; @param {i32} textOffset - The offset of the plaintext input in linear memory.
  ;; @param {i32} textLength - The length of the plaintext input in linear memory.
  ;; @param {i32} shiftKey - The shift key to use for the rotational cipher.
  ;;
  ;; @returns {(i32,i32)} - The offset and length of the ciphertext output in linear memory.
  ;;
  (func (export "rotate") (param $textOffset i32) (param $textLength i32) (param $shiftKey i32) (result i32 i32)
    (local $i i32)
    (local $current i32)
    (loop $loop

      (local.set $current (i32.load8_u (i32.add (local.get $textOffset) (local.get $i))))
      
     (if (i32.and (i32.ge_u (local.get $current) (i32.const 65)) (i32.lt_u (local.get $current) (i32.const 93)))
         (then  
            (i32.store8
            (i32.add (local.get $textOffset) (local.get $i))
            (i32.add (i32.const 65) (i32.rem_u (i32.add (i32.sub (local.get $current) (i32.const 65)) (local.get $shiftKey)) (i32.const 26))))
           )
     (else  (if (i32.and (i32.ge_u (local.get $current) (i32.const 97)) (i32.lt_u (local.get $current) (i32.const 123)))
         (then  
            (i32.store8
            (i32.add (local.get $textOffset) (local.get $i))
            (i32.add (i32.const 97) (i32.rem_u (i32.add (i32.sub (local.get $current) (i32.const 97)) (local.get $shiftKey)) (i32.const 26))))
           )
       )
    ))

      (local.set $i (i32.add (local.get $i) (i32.const 1)))

      (br_if $loop (i32.lt_u (local.get $i) (local.get $textLength)))
    )
       
    (return (local.get $textOffset) (local.get $textLength))
  )
)
