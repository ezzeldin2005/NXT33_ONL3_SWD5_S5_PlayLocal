// Sample venue data
const venues = [
    {
        id: 1,
        name: "ملعب الأهلي (فرع مدينة نصر)",
        location: "مدينة نصر، القاهرة",
        rating: 4.8,
        reviews: 215,
        price: "600 EGP/ساعة",
        // Placeholder image for a real-life football pitch
        image: "ahly-stadium.jpeg",
        features: ["5 لاعبين", "إضاءة ليلية", "غرف تغيير"],
        description: "مرافق رياضية ممتازة مع ملاعب كرة قدم معشبة وصالات رياضية حديثة. يتميز بموقع مركزي وخدمات عالية الجودة.",
        address: "طريق النصر، مدينة نصر",
        phone: "+20 100 123 4567",
        email: "info@ahlysports.eg",
        website: "https://ahlysports.eg",
        facilities: ["ملعب 5 لاعبين", "إضاءة ليلية", "غرف تغيير", "موقف سيارات", "كافيتريا"],
        sports: ["كرة قدم", "5 لاعبين"],
        timeSlots: [
            { day: "الإثنين", times: ["16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "الثلاثاء", times: ["16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "الأربعاء", times: ["16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "الخميس", times: ["16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "الجمعة", times: ["08:00-10:00", "10:00-12:00", "12:00-14:00", "14:00-16:00", "16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "السبت", times: ["08:00-10:00", "10:00-12:00", "12:00-14:00", "14:00-16:00", "16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "الأحد", times: ["16:00-18:00", "18:00-20:00", "20:00-22:00"] }
        ]
    },
    {
        id: 2,
        name: "نادي الجزيرة الرياضي (ملاعب التنس)",
        location: "الزمالك، القاهرة",
        rating: 4.9,
        reviews: 156,
        price: "450 EGP/ساعة",
        // Placeholder image for a real-life Tennis Court
        image: "gezira-tennis.jpeg",
        features: ["ملاعب تنس", "أرضية ترابية", "مدرجات"],
        description: "ملاعب تنس احترافية بأرضية ترابية، تقع في قلب الزمالك. وجهة مثالية لعشاق التنس من جميع المستويات.",
        address: "شارع سراي الجزيرة، الزمالك",
        phone: "+20 100 987 6543",
        email: "info@gezira.eg",
        website: "https://gezira.eg",
        facilities: ["ملاعب تنس", "جدران اسكواش", "موقف سيارات", "تدريب", "مطعم"],
        sports: ["تنس", "اسكواش"],
        timeSlots: [
            { day: "الإثنين", times: ["09:00-11:00", "11:00-13:00", "15:00-17:00", "17:00-19:00"] },
            { day: "الثلاثاء", times: ["09:00-11:00", "11:00-13:00", "15:00-17:00", "17:00-19:00"] },
            { day: "الأربعاء", times: ["09:00-11:00", "11:00-13:00", "15:00-17:00", "17:00-19:00"] },
            { day: "الخميس", times: ["09:00-11:00", "11:00-13:00", "15:00-17:00", "17:00-19:00"] },
            { day: "الجمعة", times: ["09:00-11:00", "11:00-13:00", "13:00-15:00", "15:00-17:00", "17:00-19:00"] },
            { day: "السبت", times: ["09:00-11:00", "11:00-13:00", "13:00-15:00", "15:00-17:00", "17:00-19:00"] },
            { day: "الأحد", times: ["09:00-11:00", "11:00-13:00", "15:00-17:00", "17:00-19:00"] }
        ]
    },
    {
        id: 3,
        name: "سكواش وورلد (مركز الجيزة)",
        location: "المهندسين، الجيزة",
        rating: 4.7,
        reviews: 98,
        price: "250 EGP/ساعة",
        // Placeholder image for a real-life Squash Court
        image: "squash-world.jpeg",
        features: ["ملاعب اسكواش", "مغلقة", "تكييف"],
        description: "أحدث ملاعب الاسكواش في الجيزة، مجهزة بتكييف مركزي ومرافق على مستوى عالمي لبطولات الاسكواش.",
        address: "شارع جامعة الدول العربية، المهندسين",
        phone: "+20 100 555 1234",
        email: "contact@squashworld.eg",
        website: "https://squashworld.eg",
        facilities: ["ملاعب اسكواش", "تكييف", "غرف تغيير", "جيم"],
        sports: ["اسكواش"],
        timeSlots: [
            { day: "الإثنين", times: ["10:00-12:00", "14:00-16:00", "16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "الثلاثاء", times: ["10:00-12:00", "14:00-16:00", "16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "الأربعاء", times: ["10:00-12:00", "14:00-16:00", "16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "الخميس", times: ["10:00-12:00", "14:00-16:00", "16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "الجمعة", times: ["10:00-12:00", "12:00-14:00", "14:00-16:00", "16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "السبت", times: ["10:00-12:00", "12:00-14:00", "14:00-16:00", "16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "الأحد", times: ["10:00-12:00", "14:00-16:00", "16:00-18:00", "18:00-20:00", "20:00-22:00"] }
        ]
    },
    {
        id: 4,
        name: "العالمي",
        location: "الفيوم , مصر",
        rating: 4.6,
        reviews: 78,
        price: "200 EGP/hour",
        image: "ahly-stadium.jpeg",
        features: ["5-a-side", "Tennis Courts", "Swimming Pool"],
        description: "Luxury hotel sports facility with premium amenities. Experience world-class sports facilities combined with five-star hospitality.",
        address: "Diplomat Area, Manama",
        phone: "0111154587",
        email: "sports@Elalmy.eg",
        website: "https://Elalmy.eg",
        facilities: ["5-a-side Pitch", "Tennis Courts", "Swimming Pool", "Spa", "Restaurant"],
        sports: ["Football", "Tennis", "Swimming"],
        timeSlots: [
            { day: "Monday", times: ["16:00-18:00", "18:00-20:00"] },
            { day: "Tuesday", times: ["16:00-18:00", "18:00-20:00"] },
            { day: "Wednesday", times: ["16:00-18:00", "18:00-20:00"] },
            { day: "Thursday", times: ["16:00-18:00", "18:00-20:00"] },
            { day: "Friday", times: ["09:00-11:00", "11:00-13:00", "15:00-17:00", "17:00-19:00"] },
            { day: "Saturday", times: ["09:00-11:00", "11:00-13:00", "15:00-17:00", "17:00-19:00"] },
            { day: "Sunday", times: ["16:00-18:00", "18:00-20:00"] }
        ]
    },
    {
        id: 5,
        name: "Helwan club",
        location: "Helwan , cairo",
        rating: 4.5,
        reviews: 92,
        price: "150 EGP/hour",
        image: "helwan-club.jpeg",
        features: ["11-a-side", "Training Grounds", "Gym"],
        description: "Traditional sports club with modern facilities. Helwan Club has been serving the community for decades with excellent sports programs.",
        address: "Helwan , cairo",
        phone: "0101234567",
        email: "info@najma.bh",
        website: "https://Helwan.eg",
        facilities: ["11-a-side Pitch", "Training Grounds", "Gym", "Locker Rooms"],
        sports: ["Football", "Athletics"],
        timeSlots: [
            { day: "Monday", times: ["16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "Tuesday", times: ["16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "Wednesday", times: ["16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "Thursday", times: ["16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "Friday", times: ["08:00-10:00", "10:00-12:00", "14:00-16:00", "16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "Saturday", times: ["08:00-10:00", "10:00-12:00", "14:00-16:00", "16:00-18:00", "18:00-20:00", "20:00-22:00"] },
            { day: "Sunday", times: ["16:00-18:00", "18:00-20:00", "20:00-22:00"] }
        ]
    }
];

// DOM elements
const navToggle = document.getElementById('navToggle');
const navMenu = document.getElementById('navMenu');
const venuesGrid = document.getElementById('venuesGrid');
const venueModal = document.getElementById('venueModal');
const modalVenueName = document.getElementById('modalVenueName');
const modalBody = document.getElementById('modalBody');
const searchInput = document.getElementById('searchInput');
const locationSelect = document.getElementById('locationSelect');

// Initialize the page
document.addEventListener('DOMContentLoaded', function() {
    loadVenues();
    setupEventListeners();
});

// Setup event listeners
function setupEventListeners() {
    // Mobile menu toggle
    navToggle.addEventListener('click', function() {
        navMenu.classList.toggle('active');
    });

    // Close modal when clicking outside
    window.addEventListener('click', function(event) {
        if (event.target === venueModal) {
            closeVenueModal();
        }
    });

    // Search on Enter key
    searchInput.addEventListener('keypress', function(e) {
        if (e.key === 'Enter') {
            searchVenues();
        }
    });

    // Smooth scrolling for navigation links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function(e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });
}

// Load venues on the page
function loadVenues(filteredVenues = venues) {
    venuesGrid.innerHTML = '';
    
    filteredVenues.forEach(venue => {
        const venueCard = createVenueCard(venue);
        venuesGrid.appendChild(venueCard);
    });
}

// Create venue card element
function createVenueCard(venue) {
    const card = document.createElement('div');
    card.className = 'venue-card';
    card.onclick = () => showVenueDetails(venue);
    
    card.innerHTML = `
        <div class="venue-image">
            <img src="/Images/${venue.image}" alt="${venue.name}" loading="lazy">
            <div class="venue-price">${venue.price}</div>
        </div>
        <div class="venue-content">
            <div class="venue-header">
                <h3 class="venue-name">${venue.name}</h3>
                <div class="venue-rating">
                    ${generateStars(venue.rating)}
                    <span>${venue.rating} (${venue.reviews})</span>
                </div>
            </div>
            <div class="venue-location">
                <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                    <path d="M21 10c0 7-9 13-9 13s-9-6-9-13a9 9 0 0 1 18 0z"></path>
                    <circle cx="12" cy="10" r="3"></circle>
                </svg>
                <span>${venue.location}</span>
            </div>
            <div class="venue-features">
                ${venue.features.map(feature => `<span class="feature-tag">${feature}</span>`).join('')}
            </div>
        </div>
    `;
    
    return card;
}

// Generate star rating HTML
function generateStars(rating) {
    const fullStars = Math.floor(rating);
    const hasHalfStar = rating % 1 !== 0;
    const emptyStars = 5 - Math.ceil(rating);
    
    let starsHTML = '<div class="stars">';
    
    // Full stars
    for (let i = 0; i < fullStars; i++) {
        starsHTML += '<span class="star">★</span>';
    }
    
    // Half star
    if (hasHalfStar) {
        starsHTML += '<span class="star">☆</span>';
    }
    
    // Empty stars
    for (let i = 0; i < emptyStars; i++) {
        starsHTML += '<span class="star empty">☆</span>';
    }
    
    starsHTML += '</div>';
    return starsHTML;
}

// Show venue details in modal
function showVenueDetails(venue) {
    modalVenueName.textContent = venue.name;
    
    modalBody.innerHTML = `
        <div class="venue-details">
            <div class="venue-gallery">
                <img src="/Images/${venue.image}" alt="${venue.name}" style="width: 100%; height: 300px; object-fit: cover; border-radius: 8px; margin-bottom: 20px;">
            </div>
            
            <div class="venue-info">
                <div style="display: flex; justify-content: space-between; align-items: start; margin-bottom: 20px;">
                    <div>
                        <h3 style="font-size: 24px; font-weight: bold; margin-bottom: 8px;">${venue.name}</h3>
                        <div style="display: flex; align-items: center; gap: 16px; color: #6b7280; font-size: 14px;">
                            <div style="display: flex; align-items: center; gap: 4px;">
                                <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                                    <path d="M21 10c0 7-9 13-9 13s-9-6-9-13a9 9 0 0 1 18 0z"></path>
                                    <circle cx="12" cy="10" r="3"></circle>
                                </svg>
                                <span>${venue.address}</span>
                            </div>
                            <div style="display: flex; align-items: center; gap: 4px;">
                                <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                                    <path d="M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z"></path>
                                </svg>
                                <span>${venue.phone}</span>
                            </div>
                            <div style="display: flex; align-items: center; gap: 4px;">
                                <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                                    <path d="M4 4h16c1.1 0 2 .9 2 2v12c0 1.1-.9 2-2 2H4c-1.1 0-2-.9-2-2V6c0-1.1.9-2 2-2z"></path>
                                    <polyline points="22,6 12,13 2,6"></polyline>
                                </svg>
                                <span>${venue.email}</span>
                            </div>
                        </div>
                    </div>
                    <div style="text-align: right;">
                        <div style="font-size: 24px; font-weight: bold; color: #16a34a; margin-bottom: 4px;">${venue.price}</div>
                        <div style="display: flex; align-items: center; gap: 4px;">
                            ${generateStars(venue.rating)}
                            <span style="color: #6b7280; font-size: 14px;">${venue.rating} (${venue.reviews} reviews)</span>
                        </div>
                    </div>
                </div>
                
                <div style="margin-bottom: 24px;">
                    <h4 style="font-size: 18px; font-weight: 600; margin-bottom: 12px;">About</h4>
                    <p style="color: #6b7280; line-height: 1.6;">${venue.description}</p>
                </div>
                
                <div style="margin-bottom: 24px;">
                    <h4 style="font-size: 18px; font-weight: 600; margin-bottom: 12px;">Facilities</h4>
                    <div style="display: flex; flex-wrap: wrap; gap: 8px;">
                        ${venue.facilities.map(facility => `
                            <div style="display: flex; align-items: center; gap: 4px; background: #f0fdf4; color: #16a34a; padding: 6px 12px; border-radius: 6px; font-size: 14px;">
                                <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                                    <polyline points="20,6 9,17 4,12"></polyline>
                                </svg>
                                ${facility}
                            </div>
                        `).join('')}
                    </div>
                </div>
                
                <div style="margin-bottom: 24px;">
                    <h4 style="font-size: 18px; font-weight: 600; margin-bottom: 12px;">Sports Available</h4>
                    <div style="display: flex; flex-wrap: wrap; gap: 8px;">
                        ${venue.sports.map(sport => `
                            <span style="background: #f3f4f6; color: #374151; padding: 6px 12px; border-radius: 6px; font-size: 14px;">
                                ${sport}
                            </span>
                        `).join('')}
                    </div>
                </div>
                
                <div style="margin-bottom: 24px;">
                    <h4 style="font-size: 18px; font-weight: 600; margin-bottom: 12px;">Operating Hours</h4>
                    <div style="display: grid; gap: 8px;">
                        ${venue.timeSlots.map(slot => `
                            <div style="display: flex; justify-content: space-between; align-items: center; padding: 8px 0; border-bottom: 1px solid #f3f4f6;">
                                <span style="font-weight: 500;">${slot.day}</span>
                                <div style="display: flex; gap: 8px; flex-wrap: wrap;">
                                    ${slot.times.map(time => `
                                        <span style="background: #f9fafb; color: #6b7280; padding: 4px 8px; border-radius: 4px; font-size: 12px;">
                                            ${time}
                                        </span>
                                    `).join('')}
                                </div>
                            </div>
                        `).join('')}
                    </div>
                </div>
                
                <div style="display: flex; gap: 12px;">
                    <button class="btn btn-primary btn-large" onclick="bookVenue(${venue.id})">
                        Book Now
                    </button>
                    <button class="btn btn-outline btn-large" onclick="contactVenue(${venue.id})">
                        Contact Venue
                    </button>
                </div>
            </div>
        </div>
    `;
    
    venueModal.style.display = 'block';
    document.body.style.overflow = 'hidden';
}

// Close venue modal
function closeVenueModal() {
    venueModal.style.display = 'none';
    document.body.style.overflow = 'auto';
}

// Search venues
function searchVenues() {
    const searchTerm = searchInput.value.toLowerCase();
    const location = locationSelect.value.toLowerCase();
    
    let filteredVenues = venues.filter(venue => {
        const matchesSearch = !searchTerm || 
            venue.name.toLowerCase().includes(searchTerm) ||
            venue.location.toLowerCase().includes(searchTerm) ||
            venue.features.some(feature => feature.toLowerCase().includes(searchTerm));
        
        const matchesLocation = !location || 
            venue.location.toLowerCase().includes(location);
        
        return matchesSearch && matchesLocation;
    });
    
    loadVenues(filteredVenues);
    
    // Scroll to venues section
    document.getElementById('venues').scrollIntoView({
        behavior: 'smooth'
    });
}

// Show all venues
function showAllVenues() {
    searchInput.value = '';
    locationSelect.value = '';
    loadVenues(venues);
    
    // Scroll to venues section
    document.getElementById('venues').scrollIntoView({
        behavior: 'smooth'
    });
}

// Book venue (placeholder function)
function bookVenue(venueId) {
    const venue = venues.find(v => v.id === venueId);
    if (venue) {
        alert(`Booking functionality would be implemented here for ${venue.name}. This would typically open a booking form with date/time selection.`);
        closeVenueModal();
    }
}

// Contact venue (placeholder function)
function contactVenue(venueId) {
    const venue = venues.find(v => v.id === venueId);
    if (venue) {
        alert(`Contact functionality would be implemented here for ${venue.name}. This could open a contact form or show contact details.`);
        closeVenueModal();
    }
}

// Add some interactivity to the page
document.addEventListener('scroll', function() {
    const navbar = document.querySelector('.navbar');
    if (window.scrollY > 100) {
        navbar.style.boxShadow = '0 2px 10px rgba(0, 0, 0, 0.1)';
    } else {
        navbar.style.boxShadow = '0 1px 3px rgba(0, 0, 0, 0.1)';
    }
});

// Add loading animation for images
document.addEventListener('DOMContentLoaded', function() {
    const images = document.querySelectorAll('img[loading="lazy"]');
    images.forEach(img => {
        img.addEventListener('load', function() {
            this.style.opacity = '0';
            setTimeout(() => {
                this.style.transition = 'opacity 0.3s ease';
                this.style.opacity = '1';
            }, 100);
        });
    });
});