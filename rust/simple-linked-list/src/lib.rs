use std::iter::FromIterator;

type Link<T> = Option<Box<Node<T>>>;
pub struct Node<T> {
    data: T,
    next: Link<T>
}

impl<T> Node<T> {
    fn new (data: T, next: Link<T>) -> Self {
        Self {data, next}
    }
}

pub struct SimpleLinkedList<T> {
    head:Link<T>,
}

impl<T> SimpleLinkedList<T> {
    pub fn new() -> Self {
        Self{ head: None}
    }

    // You may be wondering why it's necessary to have is_empty()
    // when it can easily be determined from len().
    // It's good custom to have both because len() can be expensive for some types,
    // whereas is_empty() is almost always cheap.
    // (Also ask yourself whether len() is expensive for SimpleLinkedList)
    pub fn is_empty(&self) -> bool {
        self.head.is_none()
    }

    pub fn len(&self) -> usize {
        let mut size = 0;
        let mut node  = &self.head;

        while let Some(x)= node {
            size+= 1;
            node = &x.next;
        }

        size
    }

    pub fn push(&mut self, _element: T) {
        let node = Box::new(Node::new(_element, self.head.take()));
        self.head   = Some(node);
    }

    pub fn pop(&mut self) -> Option<T> {
        match &self.head {
            None => None,
            _ => {
                let head = self.head.take().unwrap();
                self.head = head.next;
                Some(head.data)
            }
        }
    }

    pub fn peek(&self) -> Option<&T> {
        self.head.as_ref().map(|head|&(head.data))
    }

    #[must_use]
    pub fn rev(mut self) -> SimpleLinkedList<T> {
        let mut reversed = SimpleLinkedList::new();

        while let Some(x) = self.pop() {
            reversed.push(x)
        }

        reversed
    }
}

impl<T> FromIterator<T> for SimpleLinkedList<T> {
    fn from_iter<I: IntoIterator<Item = T>>(_iter: I) -> Self {
        let mut list = SimpleLinkedList::new();
        for item in _iter {
            list.push(item);
        }
        list
    }
}

impl<T> From<SimpleLinkedList<T>> for Vec<T> {
    fn from(mut _linked_list: SimpleLinkedList<T>) -> Vec<T> {
        let mut vec = vec![];
        while let Some(x) = _linked_list.pop() {
            vec.insert(0,x);
        }
        vec
    }
}
