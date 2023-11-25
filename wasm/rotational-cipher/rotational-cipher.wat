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
    (local $diff i32)
    (local.set $current (local.get $textOffset))
    (loop (i32.lt_u (local.get $i) (local.get $textLength))

      (local.set $current (i32.load8_u (i32.add (local.get $textOfset) (local.get $i))))
      
     (if (i32.and (i32.ge_u (local.get $current) (i32.const 65)) (i32.lt_u (local.get $current) (i32.const 93)))
         (then ( 
            (local.set $diff (i32.sub (local.get $current) (i32.const 65)))
            (local.set $diff (i32.add (local.get $diff) (local.get $shiftKey)))
            (local.set $diff (i32.rem_u (local.get $diff) (i32.const 26)))
            (i32.load8_u (i32.get $current) (local.get $diff))
           )
       )
    )

     (if (i32.and (i32.ge_u (local.get $current) (i32.const 97)) (i32.lt_u (local.get $current) (i32.const 123)))
         (then ( 
            (local.set $diff (i32.sub (local.get $current) (i32.const 97)))
            (local.set $diff (i32.add (local.get $diff) (local.get $shiftKey)))
            (local.set $diff (i32.rem_u (local.get $diff) (i32.const 26)))
            (i32.load8_u (i32.get $current) (local.get $diff))
           )
       )
    )

      (local.get $i)
      (i32.const 1)
      (i32.add)
      (local.set $i)
    )
       
    (return (local.get $textOffset) (local.get $textLength))
  )
)
