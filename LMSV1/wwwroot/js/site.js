// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function fetchUnreadNotifications(id) {
    fetch('/api/notifications/unread/' + id)
        .then(response => response.json())
        .then(notifications => {
            updateNotificationUI(notifications, id);
        })
        .catch(error => console.error('Error fetching notifications:', error));
}

function updateNotificationUI(notifications, id) {
    const notificationCount = notifications.length;
    document.getElementById('notificationCount').innerText = notificationCount;

    let notificationList = notifications.map(notification =>
        `<div class="notification-item">
            ${notification.course} - ${notification.assignment} ${notification.event}
            <button type="button" class="btn-close" aria-label="Close" onclick="markAsRead(${notification.notificationID},${id})"></button>
        </div>`
    ).join('');

    document.getElementById('notificationPopup').innerHTML = notificationList;
}

function toggleNotificationPopup() {
    let popup = document.getElementById('notificationPopup');
    popup.style.display = popup.style.display === 'none' ? 'block' : 'none';
}

function markAsRead(notificationId, id) {
    // Call API to mark notification as read, then refresh notifications
    fetch(`/api/notifications/markasread/${notificationId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => {
        if (response.ok) {
            fetchUnreadNotifications(id)
        } else {
            throw new Error('Failed to mark notification as read');
        }
    })
    .catch(error => console.error('Error:', error));
}