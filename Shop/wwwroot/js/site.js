function addToCart(event) {
    var button = event.target;
    var productName = button.getAttribute('data-product-name');

    if (button.classList.contains("products-element__btn")) {
        button.classList.remove("products-element__btn");
        button.classList.add("products-element__btn_active");
        button.textContent = "Видалити з кошику";

        $.ajax({
            url: '/Cart/AddToCart',
            type: 'POST',
            data: { productName: productName }
        });
    } else {
        button.classList.remove("products-element__btn_active");
        button.classList.add("products-element__btn");
        button.textContent = "Додати у кошик";

        $.ajax({
            url: '/Cart/DeleteFromCart',
            type: 'POST',
            data: { productName: productName }
        });
    }
}

    function toggleImage(image) {
        var productName = image.parentNode.querySelector('.products-element__name').textContent;
        var imageUrl = image.src;

        if (imageUrl.endsWith('Like.png')) {
            image.src = '/likes/Like_added.png';
            addToLikedList(productName);
        } else {
            image.src = '/likes/Like.png';
            deleteFromLikedList(productName);
        }
    }

    function addToLikedList(productName) {
        $.ajax({
            url: '/Likes/AddToLikedList',
            type: 'POST',
            data: { productName: productName },
         
            success: function () {
                console.log('Товар добавлен в список желаний');
            },
            error: function () {
                console.log('Ошибка при добавлении товара в список желаний');
            }
        });
    }

    function deleteFromLikedList(productName) {
        $.ajax({
            url: '/Likes/DeleteFromLikedList',
            type: 'POST',
            data: { productName: productName },
            
            success: function () {
                console.log('Товар удален из списка желаний');
            },
            error: function () {
                console.log('Ошибка при удалении товара из списка желаний');
            }
        });
    }

document.addEventListener('DOMContentLoaded', function () {
    const buttons = document.querySelectorAll('.category-button');

    buttons.forEach(function (button) {
        button.addEventListener('click', function () {
            if (this.classList.contains('active')) {
                this.classList.remove('active');
            } else {
                if (this.classList.contains('exclusive')) {
                    buttons.forEach(function (btn) {
                        if (btn !== button && btn.classList.contains('exclusive')) {
                            btn.classList.remove('active');
                        }
                    });
                }
                this.classList.add('active');
            }
        });

        button.addEventListener('mouseenter', function () {
            if (!this.classList.contains('active')) {
                this.classList.add('hover');
            }
        });

        button.addEventListener('mouseleave', function () {
            this.classList.remove('hover');
        });
    });
});


function resetToggleButtons() {
    const buttons = document.querySelectorAll('.category-button');
    buttons.forEach(function (button) {
        button.classList.remove('active');
    });
}


var selectedCategory = null;

function selectCategory(event, categoryLink) {
    //event.preventDefault();

    if (selectedCategory) {
        selectedCategory.classList.remove("active2");
    }

    categoryLink.classList.add("active2");
    selectedCategory = categoryLink;



}



