from django.shortcuts import render, get_object_or_404
from django.db.models import Q
from .models import Book


def book_list(request):
    """Book catalog view with search and sorting"""
    query = request.GET.get('q', '')
    sort = request.GET.get('sort', 'newest')
    
    books = Book.objects.filter(is_available=True)
    
    if query:
        books = books.filter(
            Q(title__icontains=query) | 
            Q(author__icontains=query) |
            Q(description__icontains=query)
        )
        
    if sort == 'price_asc':
        books = books.order_by('price')
    elif sort == 'price_desc':
        books = books.order_by('-price')
    elif sort == 'az':
        books = books.order_by('title')
    elif sort == 'za':
        books = books.order_by('-title')
    else:
        books = books.order_by('-created_at') # newest default
        
    context = {
        'books': books,
        'query': query,
        'current_sort': sort
    }
    return render(request, 'books/list.html', context)

def book_detail(request, slug):
    """Book detail view"""
    book = get_object_or_404(Book, slug=slug, is_available=True)
    return render(request, 'books/detail.html', {'book': book})
