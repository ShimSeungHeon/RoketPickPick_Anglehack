여기 AI 파트에 대한 내용을 추가했습니다:

---

## 🔍 로켓키친의 기술적 특징

로켓키친은 쿠팡의 기존 시스템과 자연스럽게 통합되도록 설계되었습니다. 아래는 로켓키친이 쿠팡의 기존 모듈을 어떻게 활용하는지에 대한 설명입니다.

### 1️⃣ 로켓프레시 장바구니 로직 재사용
쿠팡의 로켓프레시 장바구니 시스템을 그대로 사용해, 레시피를 선택한 후 재료를 쉽게 장바구니에 추가할 수 있게 했습니다. 기존 API를 활용하거나, 필요에 따라 맞춤형 API 엔드포인트를 통해 기능을 확장할 수 있습니다.

**구현 전략:**
- 쿠팡의 장바구니 API를 분석하여, 로켓키친의 레시피별 재료들을 장바구니에 한 번에 추가할 수 있는 기능을 구현했습니다.
- 레시피별로 그룹화된 재료들을 한 번에 추가할 수 있도록 API 호출을 최적화했습니다.

### 2️⃣ 기존 데이터베이스와의 통합
쿠팡의 현재 데이터베이스 시스템을 활용해, 레시피 데이터와 사용자 구매 이력을 효과적으로 관리합니다. 필요한 경우 새로운 테이블을 추가하거나 기존 테이블을 확장하여 로켓키친 기능을 통합합니다.

**구현 전략:**
- 기존의 사용자 구매 이력 테이블을 활용하여, 사용자 맞춤형 레시피 추천 기능을 강화했습니다.
- 새로운 레시피 테이블을 구축해, 쿠팡의 상품 데이터와 연결되도록 했습니다.
- 데이터베이스 스키마를 확장해, 새로운 레시피와 테마 데이터를 관리할 수 있게 했습니다.

### 3️⃣ 보안 및 인증
쿠팡의 기존 보안 시스템을 사용해 사용자 로그인과 인증을 처리합니다. 이로 인해 사용자의 정보가 안전하게 보호되며, 일관된 사용자 경험을 제공합니다.

**구현 전략:**
- 쿠팡의 기존 인증 시스템을 활용해, 로켓키친에서 사용자 로그인을 처리합니다.
- 사용자 세션 관리 및 권한 인증을 위한 기존의 보안 프로토콜을 유지하며, 새로운 기능 추가 시에도 동일한 보안 기준을 적용합니다.

### 4️⃣ AI 기반 추천 시스템
로켓키친의 AI는 사용자가 제공하는 정보와 쿠팡의 데이터베이스에 저장된 정보를 바탕으로 맞춤형 요리와 재료를 추천합니다. 이 시스템은 사용자의 경험을 확장하고 개인화된 서비스를 제공합니다.

**구현 전략:**
- **RAG(리트리버 증강 생성) 기술**을 활용하여, AI가 쿠팡 데이터베이스에서 관련된 정보를 검색한 후, 이를 바탕으로 추천을 생성합니다.
- 사용자가 입력한 요리 주제와 필요한 상황에 맞춰 AI가 적절한 레시피를 제안하고, 추천된 재료를 한 번의 클릭으로 장바구니에 추가할 수 있도록 구현했습니다.
- AI는 사용자로부터 제공받은 정보와 기존의 구매 이력을 분석하여, 더욱 개인화된 추천을 제공합니다.
- 쿠팡 키친의 AI는 계속해서 학습하여 더 나은 추천 결과를 제공하고, 사용자의 피드백을 반영하여 성능을 향상시킵니다.

---

## 🚀 구현 계획

### 1️⃣ 요구 사항 분석 및 기능 설계

#### 1. 식재료 구매의 불편함 해결
- **현재 상황:**  
  쿠팡의 로켓프레시 서비스는 개별 식재료 구매가 가능하지만, 사용자가 특정 요리를 위해 필요한 모든 재료를 하나하나 찾아야 하는 불편함이 있습니다.

- **해결 방안:**  
  레시피 기반으로 필요한 모든 식재료를 자동으로 장바구니에 추가하는 기능을 제공해, 사용자가 한 번의 클릭으로 필요한 모든 재료를 손쉽게 구매할 수 있게 합니다.

#### 2. 재고 관리의 어려움 해결
- **현재 상황:**  
  쿠팡은 다양한 식재료를 보유하고 있지만, 어떤 재료가 더 많이 사용되고 유행하는지를 파악하기 어렵습니다.

- **해결 방안:**  
  레시피 기반 구매 데이터를 활용해 인기 있는 재료를 분석하고, 이를 바탕으로 재고를 최적화합니다. 이렇게 하면 불필요한 재고를 줄이고, 재고 회전율을 높일 수 있습니다.

#### 3. 사용자 맞춤형 경험 제공
- **현재 상황:**  
  현재의 식재료 구매 과정은 개인 맞춤형 경험을 제공하는 데 한계가 있습니다.

- **해결 방안:**  
  AI 기반 추천 시스템을 통해 사용자의 취향에 맞는 레시피와 식재료를 추천하고, 사용자의 과거 구매 데이터를 분석해 맞춤형 서비스를 제공합니다.

---

## 💡 추가 정보

- **문의사항:** Jinnya8166@gmail.com
- **GitHub 리포지토리:https://github.com/ShimSeungHeon/RoketPickPick_Anglehack**


Here’s the English version of the provided README:

---

## 🔍 Technical Features of Rocket Kitchen

Rocket Kitchen is designed to seamlessly integrate with Coupang’s existing systems. Below is an explanation of how Rocket Kitchen leverages Coupang’s existing modules.

### 1️⃣ Reuse of Rocket Fresh Cart Logic
Rocket Kitchen uses Coupang’s existing Rocket Fresh cart system, allowing users to easily add ingredients to their cart after selecting a recipe. The existing API is utilized, and customized API endpoints are added where necessary to extend functionality.

**Implementation Strategy:**
- Analyzed Coupang’s cart API to implement the functionality of adding recipe-specific ingredients to the cart in one go.
- Optimized API calls to allow users to add grouped ingredients from a recipe to the cart with a single click.

### 2️⃣ Integration with Existing Databases
Rocket Kitchen effectively manages recipe data and user purchase history by leveraging Coupang’s current database system. New tables are added or existing tables are extended to integrate Rocket Kitchen's features where needed.

**Implementation Strategy:**
- Enhanced personalized recipe recommendation functionality by utilizing the existing user purchase history tables.
- Built a new recipe table that links to Coupang’s product data.
- Expanded the database schema to manage new recipes and themed data.

### 3️⃣ Security and Authentication
Rocket Kitchen uses Coupang’s existing security system to handle user login and authentication, ensuring user information is securely protected while providing a consistent user experience.

**Implementation Strategy:**
- Utilized Coupang’s existing authentication system for handling user login in Rocket Kitchen.
- Maintained existing security protocols for session management and user authorization, applying the same standards to new features.

### 4️⃣ AI-Powered Recommendation System
Rocket Kitchen’s AI recommends personalized recipes and ingredients based on user-provided information and data stored in Coupang’s database. This system enhances user experience and delivers a personalized service.

**Implementation Strategy:**
- Utilized **RAG (Retrieval-Augmented Generation) technology** to have the AI search for relevant information from Coupang’s database, and generate recommendations based on that data.
- The AI suggests appropriate recipes based on the cooking theme and specific situation provided by the user, and allows the recommended ingredients to be added to the cart with a single click.
- The AI analyzes user-provided information and purchase history to deliver more personalized recommendations.
- Rocket Kitchen’s AI continuously learns to provide better recommendation results, improving its performance based on user feedback.

---

## 🚀 Implementation Plan

### 1️⃣ Requirements Analysis and Feature Design

#### 1. Resolving Inconvenience in Ingredient Purchase
- **Current Situation:**  
  Coupang’s Rocket Fresh service allows individual ingredient purchases, but users face the inconvenience of having to search for each ingredient needed for a specific recipe.

- **Solution:**  
  Offer a feature that automatically adds all ingredients needed for a recipe to the cart, allowing users to easily purchase everything with a single click.

#### 2. Addressing Challenges in Inventory Management
- **Current Situation:**  
  Coupang holds a variety of ingredients, but it is challenging to determine which ingredients are most used or trending.

- **Solution:**  
  Utilize recipe-based purchase data to analyze popular ingredients, and optimize inventory accordingly. This reduces unnecessary stock and improves inventory turnover.

#### 3. Providing a Personalized User Experience
- **Current Situation:**  
  The current ingredient purchase process has limitations in offering a personalized user experience.

- **Solution:**  
  Implement an AI-powered recommendation system to suggest recipes and ingredients that match the user’s preferences, and analyze past purchase data to provide a tailored service.

---

## 💡 Additional Information

- **Contact:** Jinnya8166@gmail.com
- **GitHub Repository:https://github.com/ShimSeungHeon/RoketPickPick_Anglehack** 

---





---

Made with ❤️ by the RocketKitchen Team

--- 







