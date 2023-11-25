(module
  ;;
  ;; count the number of 1 bits in the binary representation of a number
  ;;
  ;; @param {i32} number - the number to count the bits of
  ;;
  ;; @returns {i32} the number of 1 bits in the binary representation of the number
  ;;
  (func (export "eggCount") (param $number i32) (result i32)
        (local $count i32)
    (if (i32.and (local.get $number) (i32.const 0x00000001)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00000002)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00000004)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00000008)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00000010)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00000020)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00000040)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00000080)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00000100)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00000200)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00000400)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00000800)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00001000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00002000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00004000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00008000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))        
    (if (i32.and (local.get $number) (i32.const 0x00010000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00020000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00040000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00080000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00100000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00200000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00400000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x00800000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) ))) 
    (if (i32.and (local.get $number) (i32.const 0x01000000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x02000000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x04000000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x08000000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) ))) 
    (if (i32.and (local.get $number) (i32.const 0x10000000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x20000000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x40000000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) )))
    (if (i32.and (local.get $number) (i32.const 0x80000000)) (then (local.set $count (i32.add (i32.const 1) (local.get $count) ) ))) 
    
    (return (local.get $count))
  )
)
